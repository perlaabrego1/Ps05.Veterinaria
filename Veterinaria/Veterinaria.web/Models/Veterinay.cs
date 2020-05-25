using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.web.Models
{
    public class Veterinay
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<Consult> Consults { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}