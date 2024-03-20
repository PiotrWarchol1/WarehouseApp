using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp.Components.CsvReader.Models
{
    public class Helmet
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Country {  get; set; }
        public int Cyl { get; set; }
        public int City { get; set; }
        public int Hwy { get; set; }
        public int Combined { get; set; }
    }
}
