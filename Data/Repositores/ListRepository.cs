using Microsoft.EntityFrameworkCore;
using WarehouseApp.Data;
using WarehouseApp.Entities;

namespace WarehouseApp.Repositores
{
    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly WarehouseAppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private List<T> _items = new List<T>();
        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemove;

        public ListRepository(WarehouseAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
            _dbSet = _dbContext.Set<T>();
        }
        public T? GetByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }

        public T? GetById(int id)
        {
            return _items[id-1];
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public void Add(T _item)
        {
            _items.Add(_item);
            _item.Id = _items.Count;
            ItemAdded?.Invoke(this, _item);
        }       
        public void Remove(T _item)
        {
            _items.RemoveAt(_item.Id - 1);
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].Id = i + 1;
            }
            ItemRemove?.Invoke(this, _item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
