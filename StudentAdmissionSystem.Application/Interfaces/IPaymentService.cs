using StudentAdmissionSystem.Application.DTOs;
using StudentAdmissionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.Interfaces
{
    public interface IPaymentService
    {
        object CreatePayment(decimal amount, string currency);
        PaymentResponseDto VerifyPayment(string orderId, string paymentId, string signature, int studentId);
     
    }
}
