using SuppTrackerProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppTrackerProject.Services.Calculators
{
    public static class SupplementCalcs
    {

        public static string DaysLeftCalculator(SupplementUser supplementUser)
        {
            return Math.Floor(((supplementUser.PartialWeight - supplementUser.EmptyWeight) / (supplementUser.FullWeight - supplementUser.EmptyWeight) + supplementUser.NumberOfNew) * supplementUser.Supplement.Servings / supplementUser.ServingsPerDay).ToString("#.");
        }

        public static string PeriodCalculator(SupplementUser supplementUser, int numberOfDays)
        {
            int daysLeft = int.Parse(DaysLeftCalculator(supplementUser));
            return (daysLeft >= numberOfDays) ? "Good" : "Need " + Math.Ceiling((numberOfDays - daysLeft) / (supplementUser.Supplement.Servings / supplementUser.ServingsPerDay)).ToString();

        }

        public static string RemainingQuantityCalculator(SupplementUser supplementUser)
        {
            return ((supplementUser.PartialWeight - supplementUser.EmptyWeight) / (supplementUser.FullWeight - supplementUser.EmptyWeight) + supplementUser.NumberOfNew).ToString("#.000");
        }
    }
}
