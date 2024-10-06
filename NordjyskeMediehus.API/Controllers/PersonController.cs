using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordjyskeMediehus.Domain.Entities;
using NordjyskeMediehus.Domain.Repository;
using System.Net.Mime;

namespace NordjyskeMediehus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    //[ApiVersion("1.0")]

    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {

            _personRepository = personRepository;
        }


        /// <summary>
        /// Get all names and phone numbers in the API's database 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpGet]
        public  ActionResult<List<Person>> GetAll()
            => Ok( _personRepository.GetAll());


        /// <summary>
        /// Get a person with the specified ID's Name and phone number. 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Person> GetById(int id)
        {
            var entity = _personRepository.GetById(id);

            if (entity != null)
                return Ok(entity);
            else
                return NotFound(new ArgumentNullException());
        }

        /// <summary>
        /// Add and new person with Name and phone number to the API's database by posting a Person in the body
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> CreatePerson([FromBody] Person person)
        {
            if (person is null)
                return BadRequest(new ArgumentNullException());

           _personRepository.Add(person);

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

    }
}
