using Microsoft.Extensions.DependencyInjection;
using WarehouseApp.Entities;
using WarehouseApp.Repositores;
using WarehouseApp;
using WarehouseApp.UserCommunication;
using WarehouseApp.Components.CsvReader;
using Microsoft.EntityFrameworkCore;
using WarehouseApp.Data;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IRepository<Helmet>, ListRepository<Helmet>>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddDbContext<WarehouseAppDbContext>(options=>options
    .UseSqlServer("Data Source=DESKTOP-9UOSCF3\\SQLEXPRESS;Initial Catalog=WarehouseAppStorage;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
 
var servicesProvider = services.BuildServiceProvider();
var app = servicesProvider.GetService<IApp>();

app.Run();
