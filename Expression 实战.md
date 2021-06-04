# Expression 实战

在工作中，遇到需要把一个数据集转化为具体的数据实体。

在C#中，我们的数据集一般用`DataSet`和`DataTable`进行装载。

```c#
public DataTable FetchData(string cmdText,params SqlParameter[] parameters)
{
    using(SqlConnection conn = new SqlConnection(connectionString))
    {
        if(conn.Status != ConnectionStatus.Closed)
        {
            conn.Close();
        }
        conn.Open();
        using(SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = cmdText;
            cmd.Parameters.AddRange(parameters);
            DataTable dt = new DataTable();
            using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
```

那么，这里模拟一个数据实体对象和模拟访问数据库，返回一个数据集。

```c#
public class Person
{
	public int ID { get; set; }
	public string UserName { get; set; }
	public decimal Age { get; set; }
	public decimal Height { get; set; }
	public short Gender { get; set; }
	public DateTime Birthday { get; set; }
	public string Address { get; set; }
	public string Phone { get; set; }
}

public DataTable GenerateDataTable()
{
	DataTable dt = new DataTable();
	foreach(PropertyInfo prop in typeof(Person).GetProperties().Where(t => t.PropertyType.IsPublic && t.CanWrite))
	{
		dt.Columns.Add(prop.Name,prop.PropertyType);
	}
	Random random = new Random();
	Enumerable.Range(1, 10).ToList().ForEach(p =>
	{
		int age = random.Next(24,31);
		dt.Rows.Add(
			p, 
			$"username_{p}",
			age,
			random.Next(154,200),
			random.Next(0,3),
			DateTime.Now.AddYears(-age),
			"SiChuan University",
			$"1528239{random.Next(1000,10000)}"
		);
	});
	return dt;
}
```

普通情况下，一般采用的反射进行实体填充。

```c#
// 方法一
public static class ObjectExtension
{
	public static T Convert2Obj<T>(this DataRow row) where T : class
	{
		if (null == row)
		{
			return null;
		}
		Type type = typeof(T);
		T obj = Activator.CreateInstance(type) as T;
		var props = type.GetProperties().Where(t => t.PropertyType.IsPublic && t.CanWrite);
		foreach (PropertyInfo prop in props)
		{
			if (null != row[prop.Name])
			{
				if (!string.IsNullOrEmpty(row[prop.Name].ToString()))
				{
					prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType));
				}
				else if (prop.PropertyType.Name == "String")
				{
					prop.SetValue(obj, string.Empty);
				}
			}
		}
		return obj;
	}
}
```

上述代码，采用的是一个泛型的`DataRow`的转化工具，能进行批量操作。

测试代码如下：

```c#
var dt = GenerateDataTable();
List<Person> list = new List<Person>();
foreach(DataRow row in dt.Rows){
    list.Add(row.Convert2Obj<Person>());
}
```

![数据集数据](C:\Users\LuoLian\AppData\Roaming\Typora\typora-user-images\image-20210410212239396.png)

![转化后的对象集](C:\Users\LuoLian\AppData\Roaming\Typora\typora-user-images\image-20210410212300860.png)

用反射的方式进行操作，结果是复合预期的。但是反射执行效率比较低，最好的方式是什么呢?

```c#
// 方法二
public Person Convert2Person(DataRow row){
	if(null != row)
	{
		Person p = new Person();
		p.ID = Convert.ToInt32(row["ID"]);
		p.UserName = Convert.ToString(row["UserName"]);
		p.Age = Convert.ToDecimal(row["Age"]);
		p.Height = Convert.ToDecimal(row["Height"]);
		p.Gender = Convert.ToInt16(row["Gender"]);
		p.Birthday = Convert.ToDateTime(row["Birthday"]);
		p.Address = Convert.ToString(row["Address"]);
		p.Phone = Convert.ToString(row["Phone"]);
		return p;
	}
	return null;
}
```

这种采用的直接调用，效率最为高效，但是这种代码不具有普遍性，也就是说，如果数据类切换`Animal`那么，代码里面还要做一套`Convert2Animal`的。那么是否可以将`Convert2XXX`这个方法进行动态生成呢？传入的对象不一样，最后生成的方法也就不一样。有的，可以采用`Expression`来动态生成Lambda语句。

> (double x, double y)=> Math.Sin(x) + Math.Cos(y);

用`Expression`是如何实现的?

```C#
private Func<double,double,double> GetMathSinAddCoos()
{
    var exp1 = Expression.Parameter(typeof(double),"x");
    var exp2 = Expression.Parameter(typeof(double),"y");
    var sin = Expression.Call(null,typeof(Math).GetMethod("Sin", BindingFlags.Static | BindingFlags.Public),exp1);
    var cos = Expression.Call(null,typeof(Math).GetMethod("Cos",BindingFlags.Static | BindingFlags.Public),exp2);
    var result = Expression.Add(sin,cos);
    var lambda = Expression.Lambda<double,double,double>(result,exp1,exp2);
    return lambda.Complie();
}
```

仿照上述代码，可以将`DataRow`转化为具体对象也这样生成一个有返回值的泛型委托。

```c#
// 方法三
public static Func<DataRow, T> ConvertToObject<T>() where T : class
{
	var parameter = Expression.Parameter(typeof(DataRow), "row");// 定义一个DataRow类型的参数，名字叫row
	var targetType = typeof(T);
	var props = targetType.GetProperties().Where(p => p.PropertyType.IsPublic && p.CanWrite);
	List<MemberBinding> list = new List<MemberBinding>();
	var getItemMethod = typeof(DataRow).GetMethod("get_Item", new[] { typeof(string) });// 获取row[] 这个方法。
	MethodInfo toStringMethod = typeof(object).GetMethod("ToString"); // 获取对象的ToString方法。
	foreach (PropertyInfo prop in props)
	{
		var val = Expression.Call(parameter, getItemMethod, Expression.Constant(prop.Name));// 获取row["col"]的值
		var toStringValue = Expression.Call(val, toStringMethod); // 获取 row["col"].ToString() 的值
		var isNotNull = Expression.NotEqual(Expression.Constant(null), val); // row["col"] != null
		var isNotEmpty = Expression.NotEqual(Expression.Constant(""), toStringValue); // row["col"].ToString() != ""
		var andCondition = Expression.And(isNotNull, isNotEmpty); // row["col"] != null && row["col"].ToString() != ""

		var tmpifTrue = Expression.Convert(val, prop.PropertyType);
		var tmpifFalse = GetConstantExp(prop.PropertyType);

		var condi = Expression.Condition(andCondition, tmpifTrue, tmpifFalse);

		list.Add(Expression.Bind(prop, condi));
	}
	var validate = Expression.NotEqual(parameter, Expression.Constant(null, typeof(DataRow)));
	var ifTrue = Expression.MemberInit(Expression.New(targetType), list); // 创建数据对象。
	var ifFalse = Expression.Constant(null, targetType);
	var condition = Expression.Condition(validate, ifTrue, ifFalse);
	var lambda = Expression.Lambda<Func<DataRow, T>>(condition, parameter);
	return lambda.Compile();
}
```

这样子，只有在生成表达式的时候使用了一次反射，后面都是直接调用，那么性能远远高于第一种方法，因为第一次使用反射，所哟它的性能要次于第二种方法，但是比第二种方法更具有普遍性。

性能 ：第二种 > 第三种 >> 第一种

普遍性：第一种 = 第三种 >> 第二种。

所以，更为值得推荐的是采用`Expression`来处理。