using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApp.Services.DataBase.Entities
{
    public class Driver
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }

        public Driver()
        {
            this.Cars = new HashSet<Car>();
        }
    }
}
