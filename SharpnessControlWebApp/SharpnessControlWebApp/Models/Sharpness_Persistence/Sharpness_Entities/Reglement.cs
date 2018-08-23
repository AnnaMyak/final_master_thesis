using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities
{
    public class Reglement
    {
        public Reglement()
        {
            ReglementId = System.Guid.NewGuid();
            Status = true;
            Creation = DateTime.Now;
        }
        [Key]
        public Guid ReglementId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Titel { get; set; }

        public string StainName { get; set; }
        public string OrganName { get; set; }


        [ForeignKey("StainName")]
        public Stain Stain { get; set; }
        [ForeignKey("OrganName")]
        public Organ Organ { get; set; }




        [Range(0, 1)]
        [Required]
        public float SharpnessThresholdValue { get; set; }


        [Range(0, 1)]
        [Required]
        public float Scaling { get; set; }

        [Range(1, 1000000)]
        [Required]
        public int Edges { get; set; }

        [Range(1, 1000)]
        [Required]
        public int TileSize { get; set; }

        // Sharp Area in %
        [Range(1, 100)]
        [Required]
        public int AcceptanceValue { get; set; }

        [Required]
        public bool Status { get; set; }
        public DateTime Creation { get; set; }




        public ICollection<Report> Reports { get; set; }

    }
}