using WarehouseApp.Components.CsvReader;
using WarehouseApp.Data;
using Helmet = WarehouseApp.Entities.Helmet;
using WarehouseApp.Comunication;
using WarehouseApp.Repositores;

namespace WarehouseApp
{
    public class App : IApp
    {
        private readonly IUserComunication _userComunication;
        private readonly IRepository<Helmet> _helmetRepository;
        private readonly WarehouseAppDbContext _warehouseAppDbContext;
        public App(ICsvReader csvReader, IRepository<Helmet> helmetsRepository, IUserComunication userComunication, WarehouseAppDbContext warehouseAppDbContext)
        {
            _userComunication = userComunication;
            _warehouseAppDbContext = warehouseAppDbContext;
            _helmetRepository = helmetsRepository;
            _warehouseAppDbContext.Database.EnsureCreated();
        }
        public void Run()
        {
            _helmetRepository.ItemAdded += _userComunication.OnItemAdded;
            _helmetRepository.ItemRemove += _userComunication.OnItemRemove;

            var quit = false;
            while (quit != true)

            {

                Console.WriteLine("----| Welcame to Warehause Application |----");
                Console.WriteLine("     ----------------------------------     ");
                Console.WriteLine("Warehause Application used to rent ski equipment");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Select what you want to do below by selecting the appropriate action number   ");
                Console.WriteLine("                                            ");
                Console.WriteLine("Press 1 if you want to add helmets");
                Console.WriteLine("Press 2 if you want to remove helmets");
                Console.WriteLine("Press 3 if you want read all helmets from db");
                Console.WriteLine("Press 4 if you want minimum price of all helmets");
                Console.WriteLine("Press 5 if you want by name");
                Console.WriteLine("Press q if you want quit");
                Console.WriteLine("                        ");




                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _userComunication.AddHelmet();
                        break;
                    case "2":
                        _userComunication.RemoveHelmet();
                        break;
                    case "3":
                        _userComunication.ReadAllHelmetsFromDb();
                        break;
                    case "4":
                        _userComunication.InsertData();
                        break;
                    case "5": 
                        _userComunication.UpdateHelmet(); 
                        break;
                    case "q":
                        quit= true;
                        break;
                    default:
                        Console.WriteLine("wrong option");
                        break;
                }
            }
        }
    }    
}