using CarsApp.Services.DataBase.Entities;
using System.Collections.Generic;

namespace CarsApp.Services.DataBase.Concrete
{
    public interface IRepository
    {
        IEnumerable<Car> GetCars();
        Car AddCar(Car car);
        Car GetCar(int id);
        Car UpdateCar(Car car);
        void DeleteCar(int id);
        
        IEnumerable<Driver> GetDrivers();
        Driver AddDriver(Driver driver);
        Driver GetDriver(int id);
        Driver UpdateDriver(Driver driver);
        void DeleteDriver(int id);
    }
}
