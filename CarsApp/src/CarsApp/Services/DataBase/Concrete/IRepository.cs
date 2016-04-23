using CarsApp.Services.DataBase.Entities;
using System.Collections.Generic;

namespace CarsApp.Services.DataBase.Concrete
{
    public interface IRepository
    {
        IEnumerable<Car> GetCars();
        void AddCar(Car car);
        Car GetCar(int id);
        bool UpdateCar(Car car);
        bool DeleteCar(int id);
        
        IEnumerable<Driver> GetDrivers();
        void AddDriver(Driver driver);
        Driver GetDriver(int id);
        bool UpdateDriver(Driver driver);
        bool DeleteDriver(int id);
    }
}
