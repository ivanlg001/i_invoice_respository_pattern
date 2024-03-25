using I_Invoice_Repository_Pattern.Handlers;
using I_Invoice_Repository_Pattern.Models;
using I_Invoice_Repository_Pattern.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace I_Invoice_Repository_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private readonly ILogger<DirectoryController> _logger;
        //private readonly IPersonRepository _personRepository;
        private readonly IDirectoryHandler _directoryHandler;
 
        public DirectoryController(ILogger<DirectoryController> logger, IDirectoryHandler directoryHandler)
        {
            _directoryHandler = directoryHandler;
            _logger = logger;
        }

        [HttpGet("find-persons")]
        public IEnumerable<Person> Get()
        {
            return _directoryHandler.FindPersons();
        }

        [HttpGet("find-person-by-id")]
        public ActionResult<Person> Get([FromQuery] string id)
        {
            var result = _directoryHandler.FindPersonByIdCard(id);
            return result != default ? (ActionResult<Person>)Ok(result) : (ActionResult<Person>)NotFound();
        }

        [HttpPost("store-person")]
        public ActionResult<Person> Insert([FromBody] Person dto)
        {
            var result = _directoryHandler.StorePerson(dto);
            return result != default ? (ActionResult<Person>)Ok(result) : (ActionResult<Person>)BadRequest();
            //return id != default ? (ActionResult<Person>)CreatedAtRoute("FindOne", new { id = id }, dto) : (ActionResult<Person>)BadRequest();
        }

        [HttpPut("update-person")]
        public ActionResult<Person> Update([FromBody] Person dto)
        {
            var result = _directoryHandler.Update(dto);
            return result != default ? (ActionResult<Person>)NoContent() : (ActionResult<Person>)NotFound();
        }

        [HttpDelete("delete-person-by-id")]
        public ActionResult<Person> Delete([FromQuery] string id)
        {
            var result = _directoryHandler.DeletePersonByIdCard(id);
            return result != false ? (ActionResult<Person>)NoContent() : (ActionResult<Person>)NotFound();
        }
    }
}
