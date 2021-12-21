using Autoservice.Models;
using Microsoft.EntityFrameworkCore;

namespace Autoservice.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ClientCar> ClientCars { get; set; }
        //public DbSet<Ccar> Ccars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>().ToTable("Request");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Master>().ToTable("Master");
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<ClientCar>().ToTable("ClientCar");
            //modelBuilder.Entity<Ccar>().ToTable("Ccar");
        }
    }
}