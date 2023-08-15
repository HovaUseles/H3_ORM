using H3_ORM___Code_first.Models;
using H3_ORM___Code_first.Repositories;
using H3_ORM___Code_first.GUI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Setting up Depencency Injection
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter(level => level >= LogLevel.Warning)));
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Library_Management_Code-first;Trusted_Connection=True;MultipleActiveResultSets=true");
});

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

// Getting injected services
var bookRepository = provider.GetRequiredService<IGenericRepository<Book>>();

// Menu
Menu menu = new Menu(bookRepository);
menu.Run();
