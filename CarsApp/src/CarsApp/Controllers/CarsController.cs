using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CarsApp.Services.DataBase.Concrete;
using CarsApp.Services.DataBase.Entities;

namespace CarsApp.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return repository.GetCar(id);
        }

        [HttpPut]
        public void Put([FromBody]Car car)
        {
            repository.AddCar(car);
        }

        [HttpPost]
        public void Post([FromBody]Car car)
        {
            repository.UpdateCar(car);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteCar(id);
        }
    }
}
