using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverPlan.Models
{
    public class Tractor
    {
        [Key]
        [Required]
        [RegularExpression(@"[\w]+[\w\s]", ErrorMessage = "Please enter letter & number characters")]
        public string Tag { get; set; }

        [Required]
        public int Capacity { get; set; }

    }
}
