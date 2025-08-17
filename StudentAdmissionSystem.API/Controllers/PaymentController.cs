using StudentAdmissionSystem.Application.DTOs;
using StudentAdmissionSystem.Application.Interfaces;
using StudentAdmissionSystem.Application.Services;
using StudentAdmissionSystem.Infrastructure.Data;
using StudentAdmissionSystem.Infrastructure.Payment;
using StudentAdmissionSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentAdmissionSystem.API.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly AdmissionPaymentHandler _paymentHandler;
        private readonly IPaymentService paymentService;
        private readonly IPaymentApplicationService _paymentApplicationService;

        public PaymentController()
        {
            var keyId = ConfigurationManager.AppSettings["RazorpayKeyId"];
            var keySecret = ConfigurationManager.AppSettings["RazorpayKeySecret"];

            // ✅ Apply DI Inject:
            // Manual Dependency Injection

            var context = new ApplicationDbContext();
            var studentPaymentRepo = new StudentPaymentRepository(context);

         
            paymentService = new RazorpayPaymentService(keyId, keySecret);
            _paymentHandler = new AdmissionPaymentHandler(paymentService);


            _paymentApplicationService = new PaymentApplicationService(paymentService, studentPaymentRepo);


        }

        [HttpPost]
        [Route("api/payment/create-order")]
        public IHttpActionResult CreateOrder([FromBody] PaymentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = _paymentHandler.ProcessPayment(dto);
            return Ok(order);
        }

        [HttpPost]
        [Route("api/payment/verify")]
        public IHttpActionResult Verify(PaymentResponseDto dto)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // proper validation errors including Amount
            }

            var verified = _paymentHandler.VerifyPaymentResponce(dto);

            if (verified.Status == "Success") {
                // TODO: Save verified response in DB
                var savedPayment = _paymentApplicationService.VerifyAndSavePayment(dto);
                return Ok(savedPayment);

            }
            return Ok(verified);

        }
    }
}