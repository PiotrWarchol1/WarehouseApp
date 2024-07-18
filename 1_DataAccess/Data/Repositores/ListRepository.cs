using Microsoft.EntityFrameworkCore;
using System.Linq;
using WarehouseApp.Data;
using WarehouseApp.Entities;

namespace WarehouseApp.Repositores
{
    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly WarehouseAppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

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
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(T _item)
        {
            _dbSet.Add(_item);
            ItemAdded?.Invoke(this, _item);
        }  
        
        public void Remove(T _item)
        { 
            _dbSet.Remove(_item);
            ItemRemove?.Invoke(this, _item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
