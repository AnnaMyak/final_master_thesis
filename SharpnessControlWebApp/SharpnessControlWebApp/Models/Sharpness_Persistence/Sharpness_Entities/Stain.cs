using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities
{
    public class Stain
    {
        public Stain()
        {

            Creation = DateTime.Now;
        }


        [StringLength(100, MinimumLength = 3)]
        [Required]
        [Key]
        public string Name { get; set; }
        public DateTime Creation { get; set; }


        public ICollection<Report> Reports { get; set; }



    }
}