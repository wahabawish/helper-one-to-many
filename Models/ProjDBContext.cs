using Microsoft.EntityFrameworkCore;

namespace RealIndianGuyOneToMany.Models
{
    public class ProjDBContext : DbContext
    {
        public ProjDBContext( DbContextOptions<ProjDBContext> context) : base(context)
        {
          
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddresses> CustomersAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddresses>()
                .HasOne(_ => _.Customer)              
                .WithMany(_ => _.customerAddresses) 
                .HasForeignKey(_ => _.CustomerId);   
        }
    }
}
