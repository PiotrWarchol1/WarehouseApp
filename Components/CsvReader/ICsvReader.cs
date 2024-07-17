using WarehouseApp.Components.CsvReader.Models;

namespace WarehouseApp.Components.CsvReader
{
    public interface ICsvReader
    {
        List<Helmet> ProcessHelmets(string filePath);
    }
}
