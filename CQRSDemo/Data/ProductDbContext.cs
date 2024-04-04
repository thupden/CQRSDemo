using CQRSDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Data
{
    public class ProductDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite("DataSource=products.db;Cache=Shared");

        public DbSet<Product> Products { get; set; } 
        
    }
}
