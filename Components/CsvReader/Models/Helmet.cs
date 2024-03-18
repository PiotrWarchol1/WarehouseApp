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
        public string Division { get; set; }
        public string Name { get; set; }
        public double Cyl {  get; set; }
        public int Country { get; set; }
        public int FE { get; set; }
        public int Hwy { get; set; }
        public int Combined { get; set; }
        public string Manufacturer { get; set; }
    }
}
