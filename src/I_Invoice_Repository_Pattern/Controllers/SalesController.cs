using I_Invoice_Repository_Pattern.Handlers;
using I_Invoice_Repository_Pattern.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace I_Invoice_Repository_Pattern.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<DirectoryController> _logger;
        private readonly ISalesHandler _salesHandler;

        public SalesController(ILogger<DirectoryController> logger, ISalesHandler salesHandler)
        {
            _salesHandler = salesHandler;
            _logger = logger;
        }

        [HttpGet("find-invoice-by-id")]
        public ActionResult<Invoice> Get([FromQuery] string id)
        {
            var result = _salesHandler.FindInvoiceByIdCard(id);
            return result != default ? (ActionResult<Invoice>)Ok(result) : (ActionResult<Invoice>)NotFound();
        }

        [HttpPost("store-invoice")]
        public ActionResult<Invoice> Insert([FromBody] Invoice dto)
        {
            var result = _salesHandler.StoreInvoice(dto);
            return result != default ? (ActionResult<Invoice>)Ok(result) : (ActionResult<Invoice>)BadRequest();
        }
    }
}
