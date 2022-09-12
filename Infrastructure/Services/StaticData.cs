using Appliaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infrastructure.Services
{
    public class StaticData
    {
        public static IEnumerable<AdministrativeUnit> AdministrativeUnits()
        {
            var administrativeUnit = new List<AdministrativeUnit>() {
                new AdministrativeUnit { Key = "Sherbimi privat", Value = "Sherbimi privat" },
                new AdministrativeUnit { Key = "Sherbimi publik", Value = "Sherbimi publik" },
            };
            return administrativeUnit;
        }

        public static IEnumerable<GeneralDemand> GeneralDemands()
        {
            var generalDemand = new List<GeneralDemand>() {
                new GeneralDemand { Key = "Infrastrukture", Value = "Infrastrukture" },
                new GeneralDemand { Key = "Shkoll", Value = "Shkoll" },
                new GeneralDemand { Key = "Ujesjells", Value = "Ujesjells" },
            };
            return generalDemand;
        }

        public static IEnumerable<GeneralReason> GeneralReason()
        {
            var generalReason = new List<GeneralReason>() {
                new GeneralReason { Key = "Familja", Value = "Familja" },
                new GeneralReason { Key = "Puna", Value = "Puna" },
                new GeneralReason { Key = "Binje politike", Value = "Bindje politike" },
            };
            return generalReason;
        }

        public static IEnumerable<YesNo> YesNo()
        {
            var yesNo = new List<YesNo>() {
                new YesNo { Key = "yes", Value = "Yes" },
                new YesNo { Key = "no", Value = "No" },
            };
            return yesNo;
        }
    }
}
