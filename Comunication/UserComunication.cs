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
            Console.WriteLine("Year: ");
            var year = int.Parse(Console.ReadLine());
            Console.WriteLine("Manufacturer: ");
            var manufacturer = Console.ReadLine();
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Country: ");
            var country = double.Parse(Console.ReadLine());
            Console.WriteLine("Cyl: ");
            var cyl = int.Parse(Console.ReadLine());
            Console.WriteLine("City: ");
            var city = int.Parse(Console.ReadLine());
            Console.WriteLine("Hwy: ");
            var hwy = int.Parse(Console.ReadLine());
            Console.WriteLine("Combined: ");
            var combined = int.Parse(Console.ReadLine());


            _helmetRepository.Add(new Helmet
            {
                Year = year,
                Manufacturer = manufacturer,
                Name = name,
                Country = country,
                Cyl = cyl,
                City = city,
                Hwy = hwy,
                Combined = combined

            });
            _helmetRepository.Save();
        }

        public void RemoveHelmet()
        {
            Console.WriteLine("Helmet: ");
            var name = Console.ReadLine();

            var helmet = _helmetRepository.GetByName(name);

            _helmetRepository.Remove(helmet);
            _helmetRepository.Save();
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

        public void UpdateHelmet() {
            Console.WriteLine(_helmetRepository.GetById(327).Name);
            /*    Console
                    .WriteLine(_helmetRepository.GetByName("Red").Name);*/

            Console.WriteLine(_helmetRepository.GetByName("Black").Name);
  /*      {
            var black = _warehouseAppDbContext.ReadFirst("Name");
            Console.WriteLine(_helmetRepository.Name);
            _helmetRepository.Name = "Byk";
            _warehouseAppDbContext.SaveChanges();*/
        }

        private Helmet? ReadFirst(string name)
        {

            return _warehouseAppDbContext.Helmets.FirstOrDefault(h => h.Name == name);
        }

    }
}
