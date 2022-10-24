﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class AddNeighborhoodVM
    {
        public int? MunicipalityId { get; set; }
        public string NeighborhoodName { get; set; }

        [ValidateNever]
        public int? VillageId { get; set; }
    }
}
