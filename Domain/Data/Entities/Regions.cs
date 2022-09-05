﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Regions
    {
        public int Id { get; set; }

        public string? Name { get; set; }


        // Navigation Properties
        public ICollection<Municipalities>? Municipalities { get; set; }
    }
}
