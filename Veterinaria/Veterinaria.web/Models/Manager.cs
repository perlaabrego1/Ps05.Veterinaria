﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinaria.web.Models
{
    public class Manager
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}