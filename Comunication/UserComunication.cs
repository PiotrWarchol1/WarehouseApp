using WarehouseApp.Components.CsvReader;
using WarehouseApp.Data;
using WarehouseApp.Entities;
using WarehouseApp.Repositores;

namespace WarehouseApp.Comunication
{
    public class UserComunication : IUserComunication
    {
         ICsvReader _csvReader;
         IRepository<Helmet> _helmetRepository;
         WarehouseAppDbContext _warehouseAppDbContext;

        public UserComunication(ICsvReader csvReader, IRepository<Helmet> helmetsRepository, WarehouseAppDbContext warehouseAppDbContext)
        {
            _helmetRepository = helmetsRepository;
            _warehouseAppDbContext = warehouseAppDbContext;
            _csvReader = csvReader;
        }

        public void OnItemAdded(object? sender, Helmet e)
        {
            string helmet = ($"Data: {DateTime.Now}, Helmet added => {e.Name} from {sender?.GetType().Name}");
            Console.WriteLine(helmet);
            using (var writer = File.AppendText("Warehouse.txt"))
            {
                writer.WriteLine(helmet);
            }
        }

        public void OnItemRemove(object? sender, Helmet e)
        {
            string helmet = $"Date:  {DateTime.Now}, Helmet remove => {e.Name}  from {sender?.GetType().Name}";
            Console.WriteLine(helmet);
            using (var writer = File.AppendText("Warehouse.txt"))
            {
                writer.WriteLine(helmet);
            }
        }

        public void AddHelmet()
        {
            Console.WriteLine("Please provide the name of the Helmet");
            var item = Console.ReadLine();
            if (item.ToLower().Contains("helmet"))
            {
                var helmet = new Helmet()
                {
                    Manufacturer = item,
                    Name = item,
                    City = 1,
                    Hwy = 1200
                };
                _helmetRepository.Add(helmet);
                _helmetRepository.Save();


            }
        }

        public void RemoveHelmet()
        {
            var itemToRemove = _warehouseAppDbContext.Helmets.SingleOrDefault(helmet => helmet.Id == int.Parse(Console.ReadLine()));
            if (itemToRemove != null)
            {
                _warehouseAppDbContext.Helmets.Remove(itemToRemove);
                _warehouseAppDbContext.SaveChanges();
            }
        }

        public void ReadAllHelmetsFromDb()
        {
          

            var helmetsFromDb = _warehouseAppDbContext.Helmets.ToList();

            foreach (var helmetFromDb in helmetsFromDb)
            {
                Console.WriteLine($"\t{helmetFromDb.Id}: {helmetFromDb.Name}: {helmetFromDb.Manufacturer}");
            }
        }
        public void InsertData()
        {
            var helmets = _csvReader.ProcessHelmets("Resources\\Files\\Fuel.csv");


            foreach (var helmet in helmets)
            {
                _helmetRepository.Add(new Helmet
                {

                    Year = helmet.Year,
                    Manufacturer = helmet.Manufacturer,
                    Name = helmet.Name,
                    Country = helmet.Country,
                    Cyl = helmet.Cyl,
                    City = helmet.City,
                    Hwy = helmet.Hwy,
                    Combined = helmet.Combined
                });
            }
            _helmetRepository.Save();
        }
        public void UpdateHelmet()
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            var helmet = _helmetRepository.GetByName(name);
            Console.WriteLine();
            Console.WriteLine("New Name: ");
            name = Console.ReadLine();
            helmet.Name = name;
            _helmetRepository.Save();

        }

    }
}
