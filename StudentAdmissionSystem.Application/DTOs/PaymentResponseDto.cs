using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.DTOs
{
    public class PaymentResponseDto
    {
            
        [Required(ErrorMessage = "PaymentId is required.")]
        public string PaymentId { get; set; }

        [Required(ErrorMessage = "StudentId is required.")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public decimal? Amount { get; set; }

        public string Status { get; set; }

        public string Signature { get; set; }

        public string OrderId { get; set; }

        public string PaymentMethod { get; set; }
       
        public string Remarks { get; set; }
    }
}
