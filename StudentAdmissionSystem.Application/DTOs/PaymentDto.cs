using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.DTOs
{
    public class PaymentDto
    {
        [Required(ErrorMessage = "StudentId is required")]
        public int? StudentId { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal? Amount { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        public string Currency { get; set; }
        
    }
}
