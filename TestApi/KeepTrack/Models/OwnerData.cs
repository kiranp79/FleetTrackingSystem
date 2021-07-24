using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Models
{
    [Table("Owner", Schema = "dbo")]
    public class OwnerData
    {
        [Key]
        public long OwnerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string OwnerName { get; set; }

        [Required]
        [MaxLength(10)]
        public long OwnerContact { get; set; }

        [Required]
        [MaxLength(50)]
        public string OwnerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ownerpass { get; set; }

       //public ICollection<FleetData> Fleets { get; set; } = new List<FleetData>();
    }
}
