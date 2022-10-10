using Appliaction.Models;
using Application.Models;
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
                new GeneralDemand { Key = "Infrastruktura", Value = "Infrastruktura" },
                new GeneralDemand { Key = "Shkolla", Value = "Shkolla" },
                new GeneralDemand { Key = "Ujësjellsi", Value = "Ujësjellsi" },
            };
            return generalDemand;
        }

        public static IEnumerable<GeneralReason> GeneralReason()
        {
            var generalReason = new List<GeneralReason>() {
                new GeneralReason { Key = "Familja", Value = "Familja" },
                new GeneralReason { Key = "Puna/Biznesi", Value = "Puna/Biznesi" },
                new GeneralReason { Key = "Bindja politike", Value = "Bindja politike" },
                new GeneralReason { Key = "Shoqëria", Value = "Shoqëria" },

            };
            return generalReason;
        }

        public static IEnumerable<YesNo> YesNo()
        {
            var yesNo = new List<YesNo>() {
                new YesNo { Key = 1, Value = "Yes" },
                new YesNo { Key = 0, Value = "No" },
            };
            return yesNo;
        }


        public static IEnumerable<SuccessChance> SuccessChances()
        {
            var successChance = new List<SuccessChance>() {
                new SuccessChance { Key = "0", Value = "0%" },
                new SuccessChance { Key = "25", Value = "25%" },
                new SuccessChance { Key = "50", Value = "50%" },
                new SuccessChance { Key = "75", Value = "75%" },
                new SuccessChance { Key = "100", Value = "100%" },
            };
            return successChance;
        }


        public static IEnumerable<ActualStatus> ActualStatus()
        {
            var actualStatus = new List<ActualStatus>() {
                new ActualStatus { Key = "I pa perfunduar", Value = "I pa perfunduar" },
                new ActualStatus { Key = "Ne proces", Value = "Ne proces" },
                new ActualStatus { Key = "I perfunduar", Value = "I perfunduar" },
            };
            return actualStatus;
        }
    }
}
