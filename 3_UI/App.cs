using WarehouseApp.Components.CsvReader;
using WarehouseApp.Entities;
using WarehouseApp.Data;
using WarehouseApp.UserCommunication;
using WarehouseApp.Repositores;

namespace WarehouseApp
{
    public class App : IApp
    {
        private readonly IUserCommunication _userCommunication;
        private readonly IRepository<Helmet> _helmetRepository;

        public App(IRepository<Helmet> helmetsRepository, IUserCommunication userCommunication, WarehouseAppDbContext warehouseAppDbContext)
        {
            _userCommunication = userCommunication;
            _helmetRepository = helmetsRepository;  
        }
        public void Run()
        {
            _helmetRepository.ItemAdded += _userCommunication.OnItemAdded;
            _helmetRepository.ItemRemove += _userCommunication.OnItemRemove;

            ShowMenu();

            var quit = false;

            while (quit != true)
            {
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _userCommunication.AddHelmet();
                        break;
                    case "2":
                        _userCommunication.RemoveHelmet();
                        break;
                    case "3":
                        _userCommunication.ReadAllHelmetsFromDb();
                        break;
                    case "4":
                        _userCommunication.InsertData();
                        break;
                    case "5":
                        _userCommunication.UpdateHelmet();
                        break;
                    case "q":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("wrong option");
                        break;
                }
            }
        }

        void ShowMenu()
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
            Console.WriteLine("Press 4 if you want insert data");
            Console.WriteLine("Press 5 if you want update helmet");
            Console.WriteLine("Press q if you want quit");
            Console.WriteLine("                        ");
        }
    }   
}