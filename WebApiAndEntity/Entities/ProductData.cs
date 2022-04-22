using Microsoft.EntityFrameworkCore;
using WebApiAndEntity.Models;

namespace WebApiAndEntity.Entities
{
    public class ProductData:DbContext
    {
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("test");
        }

    }
}
