using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Veterinaria.web.Models
{
    public class Consult
    {
        public int Id { get; set; }
        [Display(Name ="Fecha consulta")]
        [Required]
       
        public DateTime ConsultDate { get; set; }
        [Display(Name ="Descripción")]
        [Required]

        public string Description { get; set; }
        [Display(Name = "Tipo consulta")]
        [Required]
        [MaxLength(20)]
        public string ConsultType { get; set; }
        [Display(Name = "Veterinaria")]
        [Required]
        [MaxLength(30)]
        public Veterinay Veterinay { get; set; }
        [Display(Name = "Mascota")]
        [Required]
        [MaxLength(20)]

        public Pet Pet { get; set; }

        public ICollection<Consult> Consults { get; set; }

    }
}