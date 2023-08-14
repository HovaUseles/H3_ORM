using H3_ORM___Database_first.Managers;
using H3_ORM___Database_first.Models;
using H3_ORM___Database_first.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Setting up Depencency Injection
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

// Getting injected services
var bookRepository = provider.GetRequiredService<IGenericRepository<Book>>();

//
BookController bookController = new BookController(bookRepository);
bookController.DisplayBooks();
