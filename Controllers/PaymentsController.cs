using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Form3Api.Services;
using Form3Api.Models;

namespace Form3Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        readonly IPaymentRepository _paymentRepository;
        public PaymentsController(IPaymentRepository paymentRespository) {
            _paymentRepository = paymentRespository;           
        }

        // GET api/payments
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<Payment>> Get()
        {
            //return _paymentRepository.Get().ToList();
            var payments = _paymentRepository.Get();
            return new JsonResult(payments);
        }

        // GET api/payments/{id}
        [HttpGet("{id:length(24)}", Name = "GetPayment")]
        public ActionResult<Payment> Get(string id)
        {
            var payment = _paymentRepository.Get(id);
            if (payment == null) return NotFound();
            return payment;
        }

        // POST api/payments
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]        
        [HttpPost]
        public ActionResult<Payment> Add(Payment payment)
        {
            _paymentRepository.Add(payment);
            return CreatedAtRoute("GetPayment", new { id = payment.Id}, payment);
        }        

        // PUT api/payments/{id}
        [HttpPut("{id:length(24)}")]
        public ActionResult<Payment> Update(string id, Payment newPayment)
        {
            var payment = _paymentRepository.Get(id);
            if (payment == null) return NotFound();            
            _paymentRepository.Update(id, newPayment);
            return CreatedAtRoute("GetPayment", new { id = id }, newPayment);
        }     

        // DELETE api/payments/{id}
        [HttpDelete("{id:length(24)}")]        
        public ActionResult<Payment> Delete(string id)
        {
            var payment = _paymentRepository.Get(id);
            if (payment == null) return NotFound();            
            _paymentRepository.Delete(id);
            return NoContent();
        }

        [HttpOptions]
        public ActionResult Options() {
            Response.Headers.Add("Allow", "DELETE,GET,OPTIONS,POST,PUT");
            return new OkResult();
        }              

    }
}
