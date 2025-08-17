using StudentAdmissionSystem.Application.DTOs;
using StudentAdmissionSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.Services
{
    public class AdmissionPaymentHandler 
    {
        private readonly IPaymentService _paymentService;

        public AdmissionPaymentHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public object ProcessPayment(PaymentDto paymentDto)
        {           
            object paymentId = _paymentService.CreatePayment(paymentDto.Amount.Value, paymentDto.Currency);
            return paymentId;
        }

        public PaymentResponseDto VerifyPaymentResponce(PaymentResponseDto paymentDto)
        {
            var paymentResponce = _paymentService.VerifyPayment(paymentDto.OrderId, paymentDto.PaymentId, paymentDto.Signature, paymentDto.StudentId);
            return paymentResponce;
        }

    }
}
