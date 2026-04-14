using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureCalc.Models
{
    public class AzureService
    {
        [Required]
        [DisplayName("Instance Size")]
        public string InstanceSize { get; set; }

        [Required]
        [Range(2, int.MaxValue, ErrorMessage ="Must have at least 2 instances (Azure SLA)")]
        [DisplayName("Number of Instances")]
        public int NumInstances { get; set; }

        //price look up 
        public static Dictionary<string, decimal> InstancePrices = new()
        {
            {"Very Small" , 0.02m },
            {"Small" , 0.08m },
            {"Medium" , 0.16m },
            {"Large", 0.32m },
            {"Very Large" , 0.64m },
            {"A6" , 0.90m },
            {"A7" , 1.80m },
        };

        public decimal CalculateYearlyCost()
        {
            int daysInYear = DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;
            decimal hourlyRate = InstancePrices[InstanceSize] * NumInstances;
            return hourlyRate * 24 * daysInYear;
        }
    }
}
