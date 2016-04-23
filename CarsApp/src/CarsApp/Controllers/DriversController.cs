﻿using System;
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
        private IRepository repository { get; set; }
        public DriversController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Driver>> Get()
        {
            return await Task.Run(() => { return repository.GetDrivers(); });
        }

        [HttpGet("{id}")]
        public async Task<Driver> Get(int id)
        {
            return await Task.Run(() => { return repository.GetDriver(id); });
        }
        
        [HttpPost]
        public async Task Update([FromBody]Driver driver)
        {
            await Task.Run(() => { repository.UpdateDriver(driver); });
        }

        [HttpPut]
        public async Task Put([FromBody]Driver driver)
        {
            await Task.Run(() => { repository.AddDriver(driver); });
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await Task.Run(() => { repository.DeleteDriver(id); });
        }
    }
}
