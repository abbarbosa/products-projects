using Microsoft.EntityFrameworkCore;
using Product_projects.Domains;

namespace Product_projects.Context
{
    public class ProductContext : DbContext
    {

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE13-S21; Database=product_project; user Id=sa; pwd=Senai@134; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
