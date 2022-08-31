using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class SuccessChances
    {
        public int Id { get; set; }

        /// <summary>
        ///  0% jo te mira,   
        ///  25% mjaftushem 
        ///  50% jo te mira
        ///  75% t mira
        ///  100% shume te mira
        /// </summary>
        public string? Unit { get; set; }
    }
}
