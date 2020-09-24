## 组织架构
* AngularForDotnetCore
+---* .vscode
|   |
+---* Components // 存放各种业务层类
|   |
|   +---*
+---* Controllers // 存放 webapi
|
+---* Models // 对象实体
|
+---* Repo // 数据库访问
|
+---* Utils // 帮助类集
|
+---* Program.cs //启动程序
|
+---* Startup.cs // 配置

## 新建工程
```bash
dotnet new webapi -n AngularForDotnetCore
```

## 添加各类引用
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite #本次采用Sqlite进行存储数据
dotnet add package Microsoft.EntityFrameworkCore.Sqlserver
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson #前端传入Json对象，后台自动映射
dotnet add package Microsoft.AspNet.WebApi.Cors # 处理跨站点访问
dotnet add package AutoMapper # 
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection # 添加映射关系
```

## 创建DB
```C#
public class ApiDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionBuilder optionBuilder)
    {
        optionBuilder.UseSqlite("Filename=angularForDotnetCore.db")
    }
}

public class Startup
{
    private readonly string MyCors = "ANY";
    public void ConfigureService(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(); // 自动将json转变为对象。
        services.AddEntityFrameworkSqlite().AddDbContext<ApiDbContext>();
        // 设置跨站点访问
        services.AddCors(opt=>{
                opt.AddPolicy(MyCors, builder=>{
                    builder.WithOrigins("http://localhost:4200")                    
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

        // 扫描当前程序集下面所有继承了Profile的对象，添加映射关系。
        service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            // 添加跨站点访问的中间件，这个必须放在 app.UseRouting() 和 app.UseEndPoints()中间。
            app.UseCors(MyCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
    }
}
```

### 映射对象
```C#
public class Person
{
    public int ID{get;set;}
    public string Name{get;set;}
    public int Age{get;set;}
    public string Address {get;set;}
}

public class PersonReadDto
{
    public int ID {get;set;}
    public string Name{get;set;}
}

public class PersonProfile: Profile
{
    public PersonProfile()
    {
        // source -> target.
        CreateMap<Person, PersonReadDto>();
        CreateMap<PersonReadDto, Person>();
    }
}
```