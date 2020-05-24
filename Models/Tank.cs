using DeliverPlann.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverPlan.Models
{
    public class Tank
    {
        [Key]
        [Required]
        [RegularExpression(@"[\w]+[\w\s]", ErrorMessage = "Please enter letter & number characters")]
        public string Tag { get; set; }

        [Range(0, 100.00)]
        public double Level { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public string CustomerID { get; set; }

    }
}
