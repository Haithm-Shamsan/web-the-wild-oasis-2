using Api_WildOasis.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WildOasis.Core.Interfaces;

namespace Api_WildOasis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private readonly IPersonRepository _repository;

        public PeopleController(IPersonRepository personRepository)
        {
            _repository = personRepository;
        }

        /// <summary>
        /// Gets all people.
        /// </summary>
        /// <returns>List of people.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            try
            {
                var people = await _repository.GetAllPeopleAsync();
                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a person by ID.
        /// </summary>
        /// <param name="id">Person ID.</param>
        /// <returns>Person with the specified ID.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID supplied.");
            }

            try
            {
                var person = await _repository.GetPersonByIdAsync(id);
                if (person == null)
                {
                    return NotFound($"Person with ID {id} not found.");
                }
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new person.
        /// </summary>
        /// <param name="newPerson">Person object to add.</param>
        /// <returns>Created person.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Person>> AddPerson([FromBody] Person newPerson)
        {
            if (newPerson == null)
            {
                return BadRequest("Person object is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid person data.");
            }

            try
            {
                var person = await _repository.AddPersonAsync(newPerson);
                return CreatedAtAction(nameof(GetPersonById), new { id = person.PersonId }, person);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing person.
        /// </summary>
        /// <param name="id">Person ID.</param>
        /// <param name="updatedPerson">Updated person object.</param>
        /// <returns>Updated person.</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Person>> UpdatePerson(int id, [FromBody] Person updatedPerson)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID supplied.");
            }

            if (updatedPerson == null)
            {
                return BadRequest("Person object is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid person data.");
            }

            try
            {
                var person = await _repository.UpdatePersonAsync(id, updatedPerson);
                if (person == null)
                {
                    return NotFound($"Person with ID {id} not found.");
                }



                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a person by ID.
        /// </summary>
        /// <param name="id">Person ID.</param>
        /// <returns>No content on success.</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletePerson(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID supplied.");
            }

            try
            {
                var success = await _repository.DeletePersonAsync(id);
                if (!success)
                {
                    return NotFound($"Person with ID {id} not found.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }

}


