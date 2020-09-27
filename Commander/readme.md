### Add Dependencies
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install --global dotnet-ef # if ef tool not exists.

```

### Add Model for Command
```C#
public class Command
{
    [Key]
    public int ID{ get; set; }
    [Required]
    [MaxLength(64)]
    public string HowTo { get; set; }
    [Required]
    public string Line { get; set; }
    [Required]
    public string Platform { get; set; }
}
```

### Create DbContext
```C#
public class CommanderContext : DbContext
{
    public CommanderContext(DbContextOpetions<CommanderContext> opt):base(opt)
    {

    }

    public DbSet<Command> Commands { get; set; }
}
```

### Add Inject in Startup
```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<CommandContext>(opt=>opt.UseSqlServer(Configuration.GetConnectionString("CommandConnection")));
}

```

### code first and use command to generate db initial file.
```bash

dotnet ef migrations add InitialMigration # use 'ef migrations remove' to undo this action.
dotnet ef database update # generate database and tables in sqlserver.

```