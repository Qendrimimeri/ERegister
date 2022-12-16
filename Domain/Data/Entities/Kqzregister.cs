using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class Kqzregister
    {
        public int Id { get; set; }
        public string? PoliticialSubject { get; set; }
        public int? NoOfvotes { get; set; }
        public int? PollCenterId { get; set; }
        public string? DataCreated { get; set; }
        public int? MunicipalityId { get; set; }
        public int? VillageId { get; set; }
        public int? NeighborhoodId { get; set; }
        public string? ElectionType { get; set; }

        public virtual Municipality? Municipality { get; set; }
        public virtual Neighborhood? Neighborhood { get; set; }
        public virtual PollCenter? PollCenter { get; set; }
        public virtual Village? Village { get; set; }
    }
}
