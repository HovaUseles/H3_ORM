using H3_ORM___Database_first;
using H3_ORM___Database_first.Managers;
using H3_ORM___Database_first.Models;
using H3_ORM___Database_first.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

// Setting up Depencency Injection
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddDbContext<LibraryManagementDataBaseFirstContext>(options =>
{
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Library_Management_DataBase-first");
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter(level => level >= LogLevel.Warning)));
});

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

// Getting injected services
var bookRepository = provider.GetRequiredService<IGenericRepository<Book>>();
var patronsRepository = provider.GetRequiredService<IGenericRepository<Patron>>();

// Creating Controllers
BookController bookController = new BookController(bookRepository, patronsRepository);
bookController.StartMenu();
