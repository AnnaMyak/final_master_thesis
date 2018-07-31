using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities
{
    public class WSI
    {
        public WSI()
        {
            WSIId = System.Guid.NewGuid();
            Creation = DateTime.Now;
        }

        [Key]
        public Guid WSIId { get; set; }
        public string UserId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Titel { get; set; }

        public string Description { get; set; }
        public string Path { get; set; }

        public DateTime Creation { get; set; }




        public ICollection<Report> Reports { get; set; }
    }
}