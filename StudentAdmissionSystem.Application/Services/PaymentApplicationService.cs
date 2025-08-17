using StudentAdmissionSystem.Application.DTOs;
using StudentAdmissionSystem.Application.Interfaces;
using StudentAdmissionSystem.Domain.Entities;
using StudentAdmissionSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.Services
{
    public class PaymentApplicationService : IPaymentApplicationService
    {
        private readonly IPaymentService _paymentService;
        private readonly IStudentPaymentRepository _paymentRepository;

        public PaymentApplicationService(IPaymentService paymentService, IStudentPaymentRepository paymentRepository)
        {
            _paymentService = paymentService;
            _paymentRepository = paymentRepository;
        }

        public object VerifyAndSavePayment(PaymentResponseDto verifiedDto)
        {
            /*var verifiedDto = _paymentService.VerifyPayment(dto.OrderId, dto.PaymentId, dto.Signature, dto.StudentId);

            if (verifiedDto.Status != "Success")
                throw new Exception("Payment verification failed: " + verifiedDto.Remarks);*/

            var payment = new StudentPayment
            {
                RazorpayPaymentId = verifiedDto.PaymentId,
                StudentId = verifiedDto.StudentId,
                Amount = verifiedDto.Amount.Value,
                PaymentStatus = verifiedDto.Status,
                RazorpayOrderId = verifiedDto.OrderId,         
                PaymentMethod = verifiedDto.PaymentMethod,
                PaymentDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

             _paymentRepository.Add(payment);
            return payment;
        }
    }
}
