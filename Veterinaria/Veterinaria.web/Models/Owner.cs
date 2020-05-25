using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Veterinaria.web.Models
{
    public class Owner
    {
        public int Id { get; set; }
        ApplicationUser Application { get; set; }

    }
}