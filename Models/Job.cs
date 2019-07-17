using System;
using System.ComponentModel.DataAnnotations;

namespace Jobsite.Models
{
    public class Job 
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; //NOTE watch this for overriding when pulling from db
    }
}