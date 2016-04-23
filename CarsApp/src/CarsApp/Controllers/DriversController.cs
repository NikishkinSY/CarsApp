using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CarsApp.Services.DataBase.Entities;
using CarsApp.Services.DataBase.Concrete;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CarsApp.Controllers
{
    [Route("api/[controller]")]
    public class DriversController : Controller
    {
        IRepository repository { get; set; }
        public DriversController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            return repository.GetDrivers();
        }

        [HttpGet("{id}")]
        public Driver Get(int id)
        {
            return repository.GetDriver(id);
        }
        
        [HttpPost]
        public void Update([FromBody]Driver driver)
        {
            repository.UpdateDriver(driver);
        }

        [HttpPut]
        public void Put([FromBody]Driver driver)
        {
            repository.AddDriver(driver);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteDriver(id);
        }
    }
}
