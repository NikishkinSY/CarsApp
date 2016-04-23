using CarsApp.Services.DataBase.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Data.Entity;

namespace CarsApp.Services.DataBase.Concrete
{
    public class Repository : IRepository
    {
        AppDBContext appDBContext = new AppDBContext();

        public IEnumerable<Car> GetCars()
        {
            var cars = appDBContext.Cars.Include(x => x.Driver).ToList();
            return cars;
        }
        public void AddCar(Car car)
        {
            appDBContext.Cars.Add(car);
            appDBContext.SaveChanges();
        }
        public Car GetCar(int id)
        {
            return appDBContext.Cars.Where(x => x.ID == id).Include(x => x.Driver).FirstOrDefault();
        }
        public bool UpdateCar(Car car)
        {
            Car dbEntry = appDBContext.Cars.Where(x => x.ID == car.ID).Include(x => x.Driver).FirstOrDefault();
            if (dbEntry != null)
            {
                dbEntry.DriverID = car.DriverID;
                dbEntry.Year = car.Year;
                dbEntry.Description = car.Description;
                appDBContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteCar(int id)
        {
            Car dbEntry = appDBContext.Cars.Where(x => x.ID == id).Include(x => x.Driver).FirstOrDefault();
            if (dbEntry != null)
            {
                appDBContext.Cars.Remove(dbEntry);
                appDBContext.SaveChanges();
                return true;
            }
            return false;
        }



        public IEnumerable<Driver> GetDrivers()
        {
            return appDBContext.Drivers.Include(x => x.Cars).ToList();
        }
        public void AddDriver(Driver driver)
        {
            appDBContext.Drivers.Add(driver);
            appDBContext.SaveChanges();
        }
        public Driver GetDriver(int id)
        {
            return appDBContext.Drivers.Where(x => x.ID == id).Include(x => x.Cars).FirstOrDefault();
        }
        public bool UpdateDriver(Driver driver)
        {
            Driver dbEntry = appDBContext.Drivers.Where(x => x.ID == driver.ID).Include(x => x.Cars).FirstOrDefault();
            if (dbEntry != null)
            {
                dbEntry.Name = driver.Name;
                appDBContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteDriver(int id)
        {
            Driver dbEntry = appDBContext.Drivers.Where(x => x.ID == id).Include(x => x.Cars).FirstOrDefault();
            if (dbEntry != null)
            {
                appDBContext.Drivers.Remove(dbEntry);
                appDBContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
