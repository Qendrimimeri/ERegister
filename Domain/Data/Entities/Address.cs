﻿using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class Address
    {
        public int Id { get; set; }
        public int? HouseNo { get; set; }
        public int? MunicipalityId { get; set; }
        public int? VillageId { get; set; }
        public int? NeighborhoodId { get; set; }
        public int? BlockId { get; set; }
        public int? StreetId { get; set; }
        public int? PollCenterId { get; set; }
        public int? WorkId { get; set; }

        public virtual Block? Block { get; set; }
        public virtual Municipality? Municipality { get; set; }
        public virtual Neighborhood? Neighborhood { get; set; }
        public virtual PollCenter? PollCenter { get; set; }
        public virtual Street? Street { get; set; }
        public virtual Village? Village { get; set; }
        public virtual Work? Work { get; set; }
    }
}
