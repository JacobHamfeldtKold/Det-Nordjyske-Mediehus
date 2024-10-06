using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordjyskeMediehus.API.HelperClasses;
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
        [ProducesResponseType(typeof(List<Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<List<Person>>> GetAll()
        {
            var entities = await _personRepository.GetAll();
            if (entities != null)
                return Ok(entities);
            else
                return NotFound(new ArgumentNullException());
        }


        /// <summary>
        /// Get a person with the specified ID's Name and phone number. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Person),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Person>> GetById(int id)
        {
            var entity = await _personRepository.GetById(id);

            if (entity != null)
                return Ok(entity);
            else
                return NotFound("No object with this id");
        }

        /// <summary>
        /// Add and new person with Name and phone number to the API's database by posting a Person in the body
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Person),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> CreatePerson([FromBody] Person person)
        {
            if (person is null)
                return BadRequest(new ArgumentNullException());

            if(!PhoneNumber.IsPhoneNbr(person.PhoneNumber))
                return BadRequest("Wrong phone number format");

            await _personRepository.Add(person);

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

    }
}
