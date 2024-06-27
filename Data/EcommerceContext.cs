using Microsoft.EntityFrameworkCore;
using EcommerceAPI.Models;

namespace EcommerceAPI.Data{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> opctions) : base(opctions)
        {

        }
        public DbSet<Product> Products { get; set;}
        public DbSet<User> Users { get; set;}
    }
}
