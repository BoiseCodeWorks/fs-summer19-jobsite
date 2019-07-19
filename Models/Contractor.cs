using System;
using System.ComponentModel.DataAnnotations;

namespace Jobsite.Models
{
    public class Contractor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PricePerHour { get; set; }
        [Required]
        public int BasePrice { get; set; }
    }
    //helper class/model
    public class ContractorOnJob : Contractor
    {
        public DateTimeOffset Timestamp { get; set; }
    }
}