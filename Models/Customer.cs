using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverPlann.Models
{
    public class Customer
    {

        public Customer()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }



        [Required]
        //[RegularExpression(@"[\w]+[\w\s]", ErrorMessage = "Please enter letter & number characters")]
        public string CompanyName { get; set; }


        [Required]
        //[RegularExpression(@"[\w]+[\w\s]", ErrorMessage = "Please enter letter & number characters")]
        public string Address { get; set; }


    }
}
