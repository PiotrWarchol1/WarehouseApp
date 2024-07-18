namespace WarehouseApp.Entities
{
    public class Helmet : EntityBase

    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Country { get; set; }
        public int Cyl { get; set; }
        public int City { get; set; }
        public int Hwy { get; set; }
        public int Combined { get; set; }
    }
}
