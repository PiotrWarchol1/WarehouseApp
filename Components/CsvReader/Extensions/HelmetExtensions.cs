using System.Runtime.CompilerServices;
using WarehouseApp.Components.CsvReader.Models;

namespace WarehouseApp.Components.CsvReader.Extensions
{
    public static class HelmetExtensions
    {
        public static IEnumerable<Helmet> ToHelmet(this IEnumerable<String> source)
        {
            IEnumerable<Helmet> result = new List<Helmet>();
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Helmet
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Country = double.Parse(columns[3]),
                    Cyl = int.Parse(columns[4]),
                    City= int.Parse(columns[5]),
                    Hwy = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }
}
