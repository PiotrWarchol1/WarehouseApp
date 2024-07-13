using Microsoft.EntityFrameworkCore;
using WarehouseApp.Entities;

namespace WarehouseApp.Data
{ 
    public class WarehouseAppDbContext : DbContext
    { 

        public WarehouseAppDbContext(DbContextOptions<WarehouseAppDbContext> options)
            : base(options) 
        {
        }
        public DbSet<Helmet> Helmets{ get; set; } 
    }
}
