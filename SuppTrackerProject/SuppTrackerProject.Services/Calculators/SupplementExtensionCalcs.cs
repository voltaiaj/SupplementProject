using SuppTrackerProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppTrackerProject.Services.Calculators
{
    public static class SupplementExtensionCalcs
    {

        public static string DaysLeftCalc(this SupplementUser supplementUser)
        {
            return Math.Floor(((supplementUser.PartialWeight - supplementUser.EmptyWeight) / (supplementUser.FullWeight - supplementUser.EmptyWeight) + supplementUser.NumberOfNew) * supplementUser.Supplement.Servings / supplementUser.ServingsPerDay).ToString("#.");
        }

        public static string PeriodCalc(this SupplementUser supplementUser, int numberOfDays)
        {
            int daysLeft = int.Parse(DaysLeftCalc(supplementUser));
            return (daysLeft >= numberOfDays) ? "Good" : "Need " + Math.Ceiling((numberOfDays - daysLeft) / (supplementUser.Supplement.Servings / supplementUser.ServingsPerDay)).ToString();
        }

        public static string RemainingQuantityCalc( this SupplementUser supplementUser)
        {
            return ((supplementUser.PartialWeight - supplementUser.EmptyWeight) / (supplementUser.FullWeight - supplementUser.EmptyWeight) + supplementUser.NumberOfNew).ToString("#.000");
        }
    }
}
