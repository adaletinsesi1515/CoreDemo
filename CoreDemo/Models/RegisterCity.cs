using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class RegisterCity
    {
        public Writer Writer { get; set; }
        public int Id { get; set; }
        public string CityName { get; set; }

        public List<RegisterCity> RegisterCities()
        {
            List<RegisterCity> cities = new List<RegisterCity>();
            cities.Add(new RegisterCity { Id = 1, CityName = "Burdur" });
            cities.Add(new RegisterCity { Id = 5, CityName = "Antalya" });
            cities.Add(new RegisterCity { Id = 2, CityName = "Isparta" });
            cities.Add(new RegisterCity { Id = 3, CityName = "Denizli" });
            return cities;
        }
    }
}

