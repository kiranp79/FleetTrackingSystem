using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace KeepTrack.Models
{
    public class Locations
    {
        
        [Required]
        public string  CityName{ get; set; }

        [Required]        
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public string Description{ get; set; }
    }
}
