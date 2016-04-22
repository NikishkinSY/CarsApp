using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CarsApp.Services.DataBase.Concrete;
using CarsApp.Services.DataBase.Entities;

namespace CarsApp.Controllers
{
    public class CarsController : Controller
    {
        IRepository repository { get; set; }
        public CarsController(IRepository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return repository.GetCars();
        }
        
        [HttpGet]
        public Car Get(int id)
        {
            return repository.GetCar(id);
        }

        [HttpPost]
        public void Insert([FromBody]Car car)
        {
            repository.AddCar(car);
        }

        [HttpPost]
        public void Update([FromBody]Car car)
        {
            repository.UpdateCar(car);
        }
        
        [HttpPost]
        public void Delete(int id)
        {
            repository.DeleteCar(id);
        }
    }
}
