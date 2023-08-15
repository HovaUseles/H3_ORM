using H3_ORM___Code_first.Models;
using H3_ORM___Code_first.Repositories;
using H3_ORM___Code_first.GUI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Setting up Depencency Injection
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddSingleton(typeof(IGenericRepository), typeof());
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Library_Management_Code-first;Trusted_Connection=True;MultipleActiveResultSets=true"));

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

// Getting injected services
var userRepository = provider.GetRequiredService<IGenericRepository<Book>>();

// Menu
Menu menu = new Menu(userRepository);
menu.Run();
