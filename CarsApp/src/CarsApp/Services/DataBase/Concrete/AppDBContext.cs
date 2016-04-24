using CarsApp.Services.DataBase.Entities;
using Microsoft.Data.Entity;

namespace CarsApp.Services.DataBase.Concrete
{
    public class AppDBContext : DbContext
    {
        private static bool _created = false;
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        public AppDBContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.Configuration["Data:DefaultConnection:ConnectionString"]);
        }
    }
}
