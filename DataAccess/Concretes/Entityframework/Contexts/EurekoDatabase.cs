using Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class EurekoDatabase : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\" EurekoDatabase\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }



        public DbSet<Insurer> Insurers { get; set; }
        public DbSet<Insured> Insured { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<TravelDetail> TravelDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Coverage> Coverages { get; set; }
        public DbSet<PolicyCoverage> PolicyCoverages { get; set; }


    }
}