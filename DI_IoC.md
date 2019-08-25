## 依赖注入
### 1. 什么是依赖注入
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 我们创建一个SkiCardController需要应用程序中的一些其他服务才能处理查看，创建和编辑的请求。具体来说，他用SkiCardContext访问数据，用UserManager<ApplicationUser>访问当前用户的信息，用IAuthorizationService检查当前用户是否有权限编辑或者查看所有请求。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 如果不用`DI`或者其他模式，SkiCardController就负责创建这些服务的新实例。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 没有`DI`的SkiCardController
```C#
public class SkiCardController:Controller
{
    private readonly SkiCardContext _SkiCardContext;
    private readonly UserManager<ApplicationUser> _UserManager;
    private readonly IAuthorizationService _AuthorizationService;
    public SkiCardController()
    {
        _SkiCardContext = new SkiCardContext(new DbContextOptions<SkiCardContext>());

        _UserManager = new UserManager<ApplicationUser>();

        _AuthorizationService = new DefaultAuthorizationService();
    }
}
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 这些看起来还算简单，但实际上这段代码是无法通过编译的。首先，我们没有为SkiCardContext指定数据库或者连接字符串，所以他没有正确创建`DbContext`。UserManager<ApplicationUser>没有默认的构造函数，UserManager公开的唯一一个构造函数需要九个参数。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserManager<ApplicationUser>类的公开构造函数
```C#
public UserManager(IUserStore<TUser> store, IOption<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidator, IEnumerable<IPasswordValidator<IUser>> passwordValidator, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider service, ILogger<UserManager<TUser>> logger)
{
    // ...
}
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 那么，我们的SkiCardController现在还需要知道如何去创建这些服务。`DefaultAuthorizationService`的构造函数也有三个参数。无论是我们的控制器，还是应用程序的其他服务，与之交互的所有服务都需要自己动手创建，这种做法显然不合适。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 这种做法除了带来大量重复代码之外，还会导致代码紧耦合。例如，SkiCardController现在知晓了`DefaultAhtorizationService`这个类的具体知识，而不是大概了解`IAuthorizationService`接口公开的方法。假如我们想要更改`DefaultAuthorizationService`的构造函数，我们还需要更改SkiCardController以及其他使用了`DefaultAuthorizationService`的类。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 紧耦合还会加大更换实现的难度。虽然我们不太可能自己去实现一个全新的授权服务，但是替换实现的能力依然很重要，他使得`mocking`变得更加容易。`mocking`这种技术的重要性则在于它能让针对应用程序中的服务之间的交互变得更加容易。

### 2. 使用服务容易解析依赖
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 依赖注入是用来解析依赖项的一种常见模式。使用依赖注入之后，创建和管理类的实例的职责就转交给某个容器。此外，每一个类都需要声明他所依赖的其他类。然后容器就可以在运行期间解析这些依赖项，并按需传递。依赖注入模式是控制反转(`IoC`)的一种形式，意思是组件自身无需直接实例化器依赖项的职责。你或许听过`IoC`容器，这是`DI`实现的另一种叫法。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 最常见的依赖注入方法是使用构造函数注入技术。使用构造函数注入时，类会声明一个构造函数，以参数的形式接受它需要的所有服务。例如，SkiCardController拥有一个接受SkiCardContext、UserManager<ApplicationUser>和`IAuthorizationService`的构造函数，容器会负责在运行期间将这些类的实例传递给它。
```C#
public class SkiCardController : Controller
{
    private readonly SkiCardContext _SkiCardContext;
    private readonly UserManager<ApplicationUser> _UserManager;
    private readonly IAthorizationService _AuthorizationService;

    public SkiCardController(SkiCardContext skiCardContext, UserManager<ApplicationUser> userManager, IAthorizationService autherizationService)
    {
        _SkiCardContext = skiCardContext;
        _UserManager = userManager;
        _AuthorizationService = autherizationService
    }
}
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 构造函数注入能够清晰地体现给定的某个类所需要的依赖。甚至连编译器都会为我们提供帮助，因为不传递必需的类无法创建SkiCardController。正如我们之前所说，这种方法的主要好处是能够让单元测试更加简单。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 依赖注入的另一种方法是属性注入，可以使用一个特性来修饰某个公开的属性，一次来表明容易应当在运行期间设置该属性的值。属性注入不如构造函数注入那么常见，也不是所有的IoC容器都支持这种方法。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 在应用程序启动时，可以向容器注册服务。注册服务的方法取决于所使用的容器。
> 注意：  
目前，依赖注入是解决依赖问题时最受欢迎的模式，但并不是唯一可用的模式。`Service Locator`模式在一段时间内曾受到`.Net`社区的追捧，使用这种模式时，服务会注册到一个中央式服务定位器。如果某个服务需要另一种服务的实例，它会向服务定位器请求该服务类型的实例。`Service Locator`模式的主要缺点是某个服务都显示地依赖服务定位器。

## ASP.NET Core 中的依赖注入
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ASP.NET Core提供了容器的基本实现，原生支持构造函数注入。在应用程序启动时，可以在Startup类的ConfigureService方法中注册服务。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Startup的ConfigureService方法
```C#
    public void ConfigureService(IServiceCollection service)
    {
        // add service here.
    }
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 哪怕在最简单的 `ASP.NET Core` MVC 项目里，为了让你的应用程序正常运行，容器也至少要包含一些服务才行。`MVC`框架自身也依赖容器的一些服务，并通过他们来正确地支持控制器激活、视图渲染以及其他核心概念。

### 使用内置容器
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 你要做的首先是添加 `ASP.NET Core` 框架所提供的服务。如果 `ASP.NET Core` 提供的每一个服务都需要你手动注册的话，ConfigureService方法很快就会失控。幸运的是框架所提供的所有功能都有对应的Add*扩展方法，可以使用这些扩展方法来轻松地添加该功能所需要的服务。例如，`AddDbContext`方法用来注册`Entity Framework`的`DbContext`。这些方法还提供了选项委托，允许你在注册服务时进行一些额外设置。例如，在注册`DbContext`类时，使用选项委托来将上下文关联到`DefaultConnection`连接字符串中指定的SQL Server数据库。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 在AlpineSkiHouse.Web中注册`DbContext`。
```C#
    service.AddDbContext<ApplicationUserContext>(options=>options.UserSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    service.AddDbContext<SkiCardContext>(options=>options.UserSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    service.AddDbContext<PassContext>(options=>options.UserSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    service.AddDbContext<PassTypeContext>(options=>options.UserSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    service.AddDbContext<RestoreContext>(options=>options.UserSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 其他需要添加的框架功能还包括用于认证和授权的Identity、启用强类型配置的Options以及启用路由、控制器和其他所有内置功能的MVC。
```C#
    service.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStore<ApplicationUserContext>()
        .AddDefaultTokenProviders();
    service.AddOptions();
    service.AddMvc();
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 下一步是注册你编写的应用程序服务或者第三方类库中包含的服务。确保任意控制器所需的任意服务都正确地注册了。在注册应用服务时，一定要考虑该服务的生命周期。
> 注意：
容器的职责之一是管理服务的生命周期。服务的生命周期是指服务所存在的时间(从被依赖注入容器创建开始，到容器释放该服务的所有实例为止)。

| 生命周期 | 描述 |
|-----|-----|
| Transient | 每次请求服务时，都会创建一个新实例。这种生命周期适合轻量级服务   |
| Scoped | 为每一个HTTP请求创建一个实例   |
| Singleton | 在每一次请求服务时，为该服务创建一个实例   |
| Instance | 与Singleton类似，但是在应用程序启动时会将该实例注册到容器   |

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 使用`AddDbContext`方法添加`DbContext`时，会使用Scoped生命周期类注册该上下文。当一个请求进入管道，如果其后续的路由需要`DbContext`的一个实例，那么就会创建一个实例，并将其提供给所有需要用到该数据库连接的服务。实际上，容器创建的服务会被限制在对应的HTTP请求中，然后用来满足该请求执行期间的所有依赖项。当请求完成后，容器就会释放所有被占用的服务，以便运行时进行清理。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 这里展示了AlpineSkiHouse.web项目中的一些应用程序服务示例。它们的服务生命周期是通过相应的Add*方法指定的。
```C#
    service.AddSingleton<IAuthorizationHandler, EditSkiCardAuthorizationHandler>();
    service.AddTransient<IEmailSender, AuthMessageSender>();
    service.AddTransient<ISmsSender, AuthMessageSender>();
    service.AddScoped<ICsrInformationService, CsrInformationService>();
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 随着应用程序服务逐渐增多，可以通过创建扩展方法来简化ConfigureService方法。举例来说，如果你的应用程序拥有许多需要注册的IAuthorizationHandler类，你就可以创建一个AddAuthorizationHandlers扩展方法。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;用来添加一组服务的扩展方法示例
```C#
public static void AddAuthorizationHandlers(this IServiceCollection services)
{
    services.AddSingleton<IAuthorizationHandler, EditSkiCardAuthorizationHandler>();
    // Add other authorization handlers
}
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 将服务添加到`IServiceCollection`之后，框架会在运行期间使用构造函数注入来连接各依赖项。例如，如果一个请求被路由到SkiCardController，框架就会使用SkiCardController的公开构造函数来创建它的实例，同时向它传递所需的服务。控制器不再知晓如何创建这些服务以及如何管理他们的生命周期。
> 注意:
在开发新功能时，可能偶尔会接收到一条类似*InvalidOperationException:Unable to resolve service for type 'ServiceType' while attempting to activate 'SomeController'*的错误消息。  
最可能的原因是忘记在ConfigureServices方法中添加对应的服务类型。在本例中添加CsrInformationService就能解决这个错误。
```C#
    services.AddScoped<IScrInformationService, CsrInformationService>()
```

### 使用第三方容器
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; `ASP.NET Core` 框架内置的容器只提供了用来支持大多数应用程序的必要功能。但.NET平台还有许多功能更加丰富的成熟的依赖注入框架。幸运的是，`ASP.NET Core`内置了一种将默认容器替换成第三方容器的方法。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 一些流行于`.NET`平台的`IoC`容器包括`Niniject`、`StructureMap`和`Autofac`。对于`ASP.NET Core`支持最好的是`Autofac`，所以我们会用它当范例。第一步引用`NuGet`包`Autofac.Extensions.DependencyInjection`。接着，我们需要对`Startup`中的ConfigureService方法做一些修改。将其修改为返回`IServiceProvider`，而不是返回原来的void。框架服务依然会被添加到`IServiceCollection`，我们的应用程序服务则会注册到`Autofac`容器。最后返回一个`AutofacServiceProvider`，它将`ASP.NET Core`提供用来取代内置容器的`Autofac`容器。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 使用`Autofac`的ConfigureServices
```C#
    public IServiceProvider ConfigureServices(IServiceCollectioin services)
    {
        // Add framework services
        service.AddDbContext<ApplicationUserContext>(options=>options.UserSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        service.AddDbContext<SkiCardContext>(options=>options.UserSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        service.AddDbContext<PassContext>(options=>options.UserSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        service.AddDbContext<PassTypeContext>(options=>options.UserSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        service.AddDbContext<RestoreContext>(options=>options.UserSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<ApplicationUser,IdentifyRole>()
        .AddEntityFrameworkStores<ApplicationUserContext>()
        .AddDefaultTokenProviders();

        services.AddOptions();
        services.AddMvc();

        // Now register our services with Autofac container
        var builder = new ContainerBuilder();
        builder.RegisterType<CsrInformationService>().As<ICsrInformationService>();
        builder.Populate(services);
        var container = builder.Build();

        // Create the IServiceProvider based on the container.
        return new AutofaceServiceProvider(container);
    }
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 这个实例相当简单，`Autofac`还提供了一些高级的功能，比如程序集扫描，可以用来查找符合你选择的条件的类。举例来说，我们可以使用程序集扫描来自动注册项目中所有的`IAuthorizationHandler`实现。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 使用程序集扫描来自动注册类型。
```C#
    var currentAssembly = Assembly.GetEntryAssembly();
    builder.RegisterAssemblyTypes(currentAssembly)
    .Where(t => t.IsAssignableTo<IAuthorizationHandler>())
    .As<IAuthorizationHandler>();
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; `Autofac`的另一个非常棒的功能是将配置分离到模块中。模块很简单，就是一个类，它包含了一组相关的服务的配置。在最简单的情况下，Autofac模块类似于为`IServiceCollection`创建扩展方法。但模块可以用来实现一些更加高级的功能。因为他们是类，在运行期间也可以发现并加载他们，这样就能实现一种插件框架了。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; `Autofac`模块简单示例
```C#
    public class AuthorizationHandlerModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            builder.RegisterAssemblyTypes(currentAssembly)
            .Where(t=>t.IsAssignableTo<IAuthorizationHandler>())
            .As<IAuthorizationHandler>();
        }
    }
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 在Startup.ConfigureServices中加载模块
```C#
    builder.RegisterModule(new AuthorizationHandlerModule());
```


