using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Veterinaria.web.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Nombre")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        [MaxLength(20)]
        public string PetType { get; set; }
        [Display(Name = "Edad")]
  
        public int Age { get; set; }
        [Display(Name = "Fecha nacimiento")]
      
        public DateTime BirthDAte { get; set; }
        [Display(Name = "Color")]
        [MaxLength(30)]
        public string Color { get; set; }
        [Display(Name = "Raza")]
        [Required]
        [MaxLength(15)]
        public string Race { get; set; }
        [Display(Name = "Peso")]
        [Required]
              public decimal weight { get; set; }

        public string ImgUrl { get; set; }
        [Display(Name = "Altura")]
        [Required]
                public decimal Height { get; set; }
        [MaxLength()]

        public Owner Owner { get; set; }
        

    }
}