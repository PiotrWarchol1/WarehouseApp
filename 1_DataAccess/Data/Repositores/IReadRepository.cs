using WarehouseApp.Entities;

namespace WarehouseApp.Repositores
{
    public interface IReadRepository<out T> where T : class, IEntity 
    {
        public IEnumerable<T> GetAll();
        public T? GetById(int id); 
        public T GetByName(string id);
    }
}
