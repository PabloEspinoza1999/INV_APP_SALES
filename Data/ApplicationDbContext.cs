using INV_APPLICATION.Models;
using Microsoft.EntityFrameworkCore;

namespace INV_APPLICATION.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Customer> TbCustomer { get; set; }
 

        public DbSet<Product> TbProduct { get; set; }

        public DbSet<User> TbUser { get; set; }

        public DbSet<Zone> TbZone { get; set; }

        public DbSet<Rol> TbRol { get; set; }
        public DbSet<Sale> TbSale { get; set; }

    }
}

