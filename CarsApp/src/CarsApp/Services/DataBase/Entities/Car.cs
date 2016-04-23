using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApp.Services.DataBase.Entities
{
    public class Car
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Driver")]
        public int DriverID { get; set; }
        public Driver Driver { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
    }
}
