## T-SQL 触发器

**触发器分为**

- [ ] BEFORE触发器*(SQL Server不支持，Oracle支持)在事件发生时触发。
- [ ] *AFTER触发器*是`SQL Server`生成的最初用于自动相应数据修改的机制。在`SQL Server 200`以前的版本中`AFTER`触发器是唯一的触发器，因此不用指明`AFTER`，也可以用`FOR`代替，**该种触发器的行为是在事件之后执行**。
- [ ] `SQL Server 2000`中新增了`INSTEAD OF触发器`，**该触发器执行某项操作，而不是触发这个触发器的操作**。

### AFTER触发器

> **AFTER**触发器是默认的触发器类型，因此关键字**AFTER**可以选。

```mssql
CREATE TRIGGER trigger_name
ON table_name
AFTER {INSERT | UPDATE | DELETE }
AS
BEGIN
	-- SQL statement
END
GO
```

#### 案例

&emsp;&emsp;在pubs数据库中生成一个触发器，打印一条消息，表示UPDATE Commands语句更新的数据行数。

```mssql
USE pubs; -- 选择pubs数据库。
GO

CREATE TRIGGER tr_cmd_upd ON dbo.Commands
AFTER UPDATE
AS
BEGIN
	PRINT 'Trigger Output '+CONVERT(VARCHAR(5),@@ROWCOUNT)+' rows were updated.';
END
GO

-- 执行一条语句，查看触发器是否生效。
UPDATE dbo.commands
SET title=title
WHERE ID = 4;
GO
```



#### INSERTED表和DELETED表

- [ ] 在大多数触发器情况下，需要知道数据修改中发生了什么变化，可以在**INSERTED**和**DELETED**表中找到这个信息。
- [ ] 案例：

```mssql
SELECT * INTO commands_copy FROM commands;
GO

CREATE TRIGGER tr_cc ON dbo.commands_copy
FOR INSERT, UPDATE, DELETE
AS
BEGIN
	PRINT 'Inserted:';
	SELECT ID, Type, Platform FROM INSERTED;
	PRINT 'Deleted:';
	SELECT ID, Type, Platform FROM DELETED;
END
```

|  语句  | INSERTED的内容 | DELETED内容 |
| :----: | :------------: | :---------: |
| INSERT |    增加的行    |     空      |
| UPDATE |      新行      |    旧行     |
| DELETE |       空       |  删除的行   |

#### 检查列更新

- [ ] **INSERT**或者**UPDATE**触发器内可以使用**UPDATE()**函数。
- [ ] 使用**UPDATE()**函数检查**INSERT**与**UPDATE**操作对数据列的影响。

```mssql
CREATE TRIGGER tr_ins_upd ON dbo.commands_copy
FOR INSERT, UPDATE
AS
BEGIN
	IF(UPDATE(ID))
	BEGIN
		RAISERROR('You can not change the ID.', 15, 1);
	END
END
```

#### 执行

- [ ] 执行AFTER触发器之前发生的事件。

  - 限制处理 -- 包括检查限制，唯一限制和主键限制。
  - 声明式引用 -- 这些操作是外部健限制定义的，保证表间的正确关系。
  - 触发操作 -- 即触发触发器的数据修改操作。这项操作发生在触发器执行之前，但结果要等到完成触发器操作之后才提交到数据库。

- [ ] 触发顺序

  - 可以有多个对应于**INSERT**，**UPDATE**，**DELETE**的触发器，**SQL Server**可以指定第一个和最后一个触发器，但中间的触发器顺序则无法确定。

- [ ] 触发顺序

  - SP_SETTRIGGERORDER过程是设置触发器顺序的工具。

  - 格式：

    ```mssql
    SP_SETTRIGGERORDER trigger_name, 顺序，'操作'.
    /*
    其中，顺序为[First | Last | None]
    	 操作为[Insert | Update | Delete]
    */
    ```

  - 例如：

    ```mssql
    SP_SETTRIGGERORDER tr_cmd_upd, FIRST, 'UPDATE';
    ```

- [ ] 建议尽量不要对同一个表的同一事件定义多个触发器，可以把相关的操作定义到一个触发器中。



#### 特殊考虑

- [ ] AFTER触发器可以用于具有级联参照完整性限制的表格中。
- [ ] WRITETEXT与**TRUNCATE TABLE**不触发触发器。
- [ ] 触发器是对象，因此要在数据库中有唯一的名称。

#### AFTER触发器的限制

- [ ] AFTER触发器只能用于表，不能用于视图。
- [ ] 一个AFTER触发器不能用在多个表上。
- [ ] TEXT, NTEXT与IMAGE列不能引用AFTER触发器。

### INSTEAD OF 触发器

> 1. SQL Server 2000引入新的Instead of 触发器。
>
> 2. Instead of 的含义：该触发器执行某项操作，而不是触发这个触发器的操作。
>
> 3. 语法格式：
>
>    ```mssql
>    CREATE TRIGGER trigger_name
>    ON table_name
>    INSTEAD OF {INSERT | UPDATE | DELETE}
>    AS
>    BEGIN
>    	-- SQL statements
>    END
>    
>    ----
>    -- 案例
>    ---
>    CREATE TRIGGER tr_cmd_cmdDB ON CommandDB.dbo.Commands
>    INSTEAD OF UPDATE
>    AS
>    BEGIN
>    	PRINT 'Trigger Output: '+CONVERT(VARCHAR(5),@@ROWCOUNT)+' rows were updated....';
>    END
>    GO
>    
>    UPDATE dbo.commands
>    SET Platform = Platform
>    WHERE ID = 4;
>    GO
>    /*
>    1. 更新操作并未执行，Instead of 触发器的作用是打印一条信息。
>    2. Instead Of触发器的执行细节。
>     2.1 触发操作 --- 触发Instead of触发器而不是触发操作。
>     2.2 限制处理 --- 对限制的检查发生在Instead of触发器操作之后。
>    */
>    ```
>
> 4.  什么时候使用Instead of触发器。
>
>    1. 数据库里的数据禁止修改。
>    2. 有可能要回滚修改的SQL语句。
>    3. 在视图中使用的触发器，AFTER触发器不能在视图中使用。
>    4. 控制数据的修改方式和流程。