using AppCodeReview.Models;
using AspNetCoreWebApi6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCodeReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly AppCodeReviewContext _dbContext;

        public PaymentController(AppCodeReviewContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Movies
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayment()
        {
            if (_dbContext.Payment == null)
            {
                return NotFound();
            }
            return await _dbContext.Payment.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> CriarPagamento(Payment payment)
        {
            switch (payment.TypeDescription)
            {
                case "credit":
                    payment.Type = 1;
                    var result =  payment.SendPaymenteOfCard(payment.PaymentDetailsCredit);
                    if (result)
                        return NoContent();
                    else
                        return NoContent();
                    break;
                case "pix":
                    payment.Type = 2;
                    var resultPix = payment.SendPaymentPix(payment.PaymentDetailsPix);
                    if (resultPix)
                        return Ok();
                    else
                        return NoContent();
                    break;
                    break;
                case "debit":
                    payment.Type = 3;
                    return NoContent();
                    break;
            }

            _dbContext.Payment.Add(payment);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
