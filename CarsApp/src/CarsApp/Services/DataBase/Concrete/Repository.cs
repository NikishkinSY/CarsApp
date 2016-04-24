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

        /// <summary>
        /// get all cars
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Car> GetCars()
        {
            var cars = appDBContext.Cars.Include(x => x.Driver).ToList();
            return cars;
        }
        /// <summary>
        /// add car to repository
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public Car AddCar(Car car)
        {
            appDBContext.Cars.Add(car);
            appDBContext.SaveChanges();

            car.Driver = GetDriver(car.DriverID);
            return car;
        }
        /// <summary>
        /// get specific car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetCar(int id)
        {
            return appDBContext.Cars.Where(x => x.ID == id).Include(x => x.Driver).First();
        }
        /// <summary>
        /// update car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public Car UpdateCar(Car car)
        {
            Car dbEntry = appDBContext.Cars.Where(x => x.ID == car.ID).Include(x => x.Driver).First();
            dbEntry.DriverID = car.DriverID;
            dbEntry.Year = car.Year;
            dbEntry.Description = car.Description;
            appDBContext.SaveChanges();

            dbEntry.Driver = GetDriver(car.DriverID);
            return dbEntry;
        }
        /// <summary>
        /// delete car
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCar(int id)
        {
            Car dbEntry = appDBContext.Cars.Where(x => x.ID == id).First();
            appDBContext.Cars.Remove(dbEntry);
            appDBContext.SaveChanges();
        }



        /// <summary>
        /// get all drivers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Driver> GetDrivers()
        {
            return appDBContext.Drivers.Include(x => x.Cars).ToList();
        }
        /// <summary>
        /// add driver
        /// </summary>
        /// <param name="driver"></param>
        public Driver AddDriver(Driver driver)
        {
            appDBContext.Drivers.Add(driver);
            appDBContext.SaveChanges();

            return driver;
        }
        /// <summary>
        /// get specific driver
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Driver GetDriver(int id)
        {
            return appDBContext.Drivers.Where(x => x.ID == id).Include(x => x.Cars).First();
        }
        /// <summary>
        /// update driver
        /// </summary>
        /// <param name="driver"></param>
        public Driver UpdateDriver(Driver driver)
        {
            Driver dbEntry = appDBContext.Drivers.Where(x => x.ID == driver.ID).Include(x => x.Cars).First();
            dbEntry.Name = driver.Name;
            appDBContext.SaveChanges();

            return dbEntry;
        }
        /// <summary>
        /// delete driver
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDriver(int id)
        {
            Driver dbEntry = appDBContext.Drivers.Where(x => x.ID == id).First();
            appDBContext.Drivers.Remove(dbEntry);
            appDBContext.SaveChanges();
        }
    }
}
