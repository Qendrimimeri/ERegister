using Appliaction.Models;
using Application.Models;

namespace Infrastructure.Services
{
    public class StaticData
    {
        public static IEnumerable<AdministrativeUnitModel> AdministrativeUnits()
        {
            var administrativeUnit = new List<AdministrativeUnitModel>() {
                new AdministrativeUnitModel { Key = "Sherbimi privat", Value = "Sherbimi privat" },
                new AdministrativeUnitModel { Key = "Sherbimi publik", Value = "Sherbimi publik" },
            };
            return administrativeUnit;
        }

        public static IEnumerable<GeneralDemandModel> GeneralDemands()
        {
            var generalDemand = new List<GeneralDemandModel>() {
                new GeneralDemandModel { Key = "Infrastruktura", Value = "Infrastruktura" },
                new GeneralDemandModel { Key = "Shkolla", Value = "Shkolla" },
                new GeneralDemandModel { Key = "Ujësjellsi", Value = "Ujësjellsi" },
            };
            return generalDemand;
        }

        public static IEnumerable<GeneralReasonModel> GeneralReason()
        {
            var generalReason = new List<GeneralReasonModel>() {
                new GeneralReasonModel { Key = "Familja", Value = "Familja" },
                new GeneralReasonModel { Key = "Puna/Biznesi", Value = "Puna/Biznesi" },
                new GeneralReasonModel { Key = "Bindja politike", Value = "Bindja politike" },
                new GeneralReasonModel { Key = "Shoqëria", Value = "Shoqëria" },

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


        public static IEnumerable<ActualStatusModel> ActualStatus()
        {
            var actualStatus = new List<ActualStatusModel>() {
                new ActualStatusModel { Key = "I pa perfunduar", Value = "I pa perfunduar" },
                new ActualStatusModel { Key = "Ne proces", Value = "Ne proces" },
                new ActualStatusModel { Key = "I perfunduar", Value = "I perfunduar" },
            };
            return actualStatus;
        }
    }
}
