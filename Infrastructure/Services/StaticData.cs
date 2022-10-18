
using Appliaction.Models;
using Application.Models;
using Application.Models.Services;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{

    public class StaticData
    {
        private readonly GeneralDemands _demands;
        private readonly GeneralReasons _reasons;
        private readonly ActualStatus _status;
        private readonly AdministrativeUnits _unit;
        private readonly SuccessChances _chances;
        private readonly YesNo _yesNo;

        public StaticData(IOptionsSnapshot<GeneralDemands> demands,
                          IOptionsSnapshot<GeneralReasons> reasons,
                          IOptionsSnapshot<ActualStatus> status,
                          IOptionsSnapshot<AdministrativeUnits> unit,
                          IOptionsSnapshot<SuccessChances> chances,
                          IOptionsSnapshot<YesNo> yesNo)
        {
            _demands = demands.Value;
            _reasons = reasons.Value;
            _status = status.Value;
            _unit = unit.Value;
            _chances = chances.Value;
            _yesNo = yesNo.Value;
        }
        public static IEnumerable<KeyValueModel> AdministrativeUnits()
        {
            
            var administrativeUnit = new List<KeyValueModel>() {
                new KeyValueModel { Key = "Sektori privat", Value = "Sektori  privat" },
                new KeyValueModel { Key = "Sektori  publik", Value = "Sektori  publik" },
            };
            return administrativeUnit;
        }

        public static IEnumerable<KeyValueModel> GeneralDemands()
        {
            var generalDemand = new List<KeyValueModel>() {
                new KeyValueModel { Key = "Infrastruktura", Value = "Infrastruktura" },
                new KeyValueModel { Key = "Shkolla", Value = "Shkolla" },
                new KeyValueModel { Key = "Ujësjellsi", Value = "Ujësjellsi" },
            };
            return generalDemand;
        }

        public static IEnumerable<KeyValueModel> GeneralReason()
        {
            var generalReason = new List<KeyValueModel>() {
                new KeyValueModel { Key = "Familja", Value = "Familja" },
                new KeyValueModel { Key = "Puna/Biznesi", Value = "Puna/Biznesi" },
                new KeyValueModel { Key = "Bindja politike", Value = "Bindja politike" },
                new KeyValueModel { Key = "Shoqëria", Value = "Shoqëria" },

            };
            return generalReason;
        }

        public static IEnumerable<YesNoModel> YesNo()
        {
            var yesNo = new List<YesNoModel>() 
            {
                new YesNoModel { Key = 1, Value = "Po" },
                new YesNoModel { Key = 0, Value = "Jo" },
            };
            return yesNo;
        }


        public static IEnumerable<KeyValueModel> SuccessChances()
        {
            var successChance = new List<KeyValueModel>() {
                new KeyValueModel { Key = "0", Value = "0%" },
                new KeyValueModel { Key = "25", Value = "25%" },
                new KeyValueModel { Key = "50", Value = "50%" },
                new KeyValueModel { Key = "75", Value = "75%" },
                new KeyValueModel { Key = "100", Value = "100%" },
            };
            return successChance;
        }


        public static IEnumerable<KeyValueModel> ActualStatus()
        {
            var actualStatus = new List<KeyValueModel>() {
                new KeyValueModel { Key = "I pa perfunduar", Value = "I pa perfunduar" },
                new KeyValueModel { Key = "Ne proces", Value = "Ne proces" },
                new KeyValueModel { Key = "I perfunduar", Value = "I perfunduar" },
            };
            return actualStatus;
        }
    }
}
