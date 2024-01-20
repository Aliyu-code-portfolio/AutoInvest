using AutoInvest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoInvest.Infrastructure.Persistent
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Address> Addresses { get; set; }





    }
    
   

}
