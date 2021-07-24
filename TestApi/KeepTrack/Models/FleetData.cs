using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KeepTrack.Models
{
    public class FleetData
    {
        [Required]
        [MaxLength(17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FleetRCNo { get; set; }

        [Required]
        [MaxLength(20)]
        public string FleetType { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        //[ForeignKey("OwnerId")]
        // public OwnerData Owner { get; set; }

        [Required]
        public long OwnerId { get; set; }
    }
}
