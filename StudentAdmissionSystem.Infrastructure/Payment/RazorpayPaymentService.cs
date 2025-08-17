using Razorpay.Api;
using StudentAdmissionSystem.Application.DTOs;
using StudentAdmissionSystem.Application.Interfaces;
using System.Collections.Generic;


 

namespace StudentAdmissionSystem.Infrastructure.Payment
{
    public class RazorpayPaymentService : IPaymentService
    {

        private readonly string _keyId;
        private readonly string _keySecret;
        private readonly RazorpayClient _client;

        public RazorpayPaymentService(string keyId, string keySecret)
        {
            _keyId = keyId;
            _keySecret = keySecret;

            _client = new RazorpayClient(_keyId, _keySecret);
        }

        public object CreatePayment(decimal amount, string currency)
        {
            var options = new Dictionary<string, object>
            {
                { "amount", amount },
                { "currency", currency },
                { "payment_capture", 1 }
            };

            Razorpay.Api.Order order = _client.Order.Create(options);
            return order.Attributes;

          
        }
        public PaymentResponseDto VerifyPayment(string orderId, string paymentId, string signature, int studentId)
        {
            
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_order_id", orderId },
                { "razorpay_payment_id", paymentId },
                { "razorpay_signature", signature }
            };

            Utils.verifyPaymentSignature(attributes);

            return new PaymentResponseDto
            {
                OrderId = orderId,
                PaymentId = paymentId,
                Status = "Success",
                StudentId = studentId
            };
           
        }
    }
}
