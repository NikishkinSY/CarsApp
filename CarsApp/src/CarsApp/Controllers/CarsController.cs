using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CarsApp.Services.DataBase.Concrete;
using CarsApp.Services.DataBase.Entities;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace CarsApp.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private IRepository repository { get; set; }
        public CarsController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Car>> Get()
        {
            return await Task.Run(() => { return repository.GetCars(); });
        }

        [HttpGet("{id}")]
        public async Task<Car> Get(int id)
        {
            return await Task.Run(() => { return repository.GetCar(id); });
        }

        [HttpPut]
        public async Task Put([FromBody]Car car)
        {
            await Task.Run(() => { repository.AddCar(car); });
        }

        [HttpPost]
        public async Task Post([FromBody]Car car)
        {
            await Task.Run(() => { repository.UpdateCar(car); });
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await Task.Run(() => { repository.DeleteCar(id); });
        }
    }
}
