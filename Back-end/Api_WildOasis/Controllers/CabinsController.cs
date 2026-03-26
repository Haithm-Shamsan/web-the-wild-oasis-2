using Api_WildOasis.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WildOasis.Core.Interfaces;

namespace Api_WildOasis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinsController : ControllerBase
    { 
            private readonly ICabinsRepository _cabinRepository;

            public CabinsController(ICabinsRepository cabinRepository)
            {
                _cabinRepository = cabinRepository;
            }

            /// <summary>
            /// Gets a cabin by its ID.
            /// </summary>
            /// <param name="id">The ID of the cabin to retrieve.</param>
            /// <returns>The requested cabin if found, otherwise a 404 Not Found.</returns>
            /// <response code="200">Returns the requested cabin</response>
            /// <response code="404">If the cabin is not found</response>
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> GetCabinByIdAsync(int id)
            {
                try
                {
                    var cabin = await _cabinRepository.GetCabinByIdAsync(id);

                    if (cabin == null)
                    {
                        return NotFound(); // 404 Not Found
                    }

                    return Ok(cabin); // 200 OK
                }
                catch (Exception ex)
                {
                    // Log the exception details (not shown here)
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
                }
            }

            /// <summary>
            /// Gets all cabins.
            /// </summary>
            /// <returns>A list of all cabins.</returns>
            /// <response code="200">Returns a list of cabins</response>
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<IActionResult> GetAllCabinsAsync()
            {
                try
                {
                    var cabins = await _cabinRepository.GetAllCabinsAsync(); // Assuming this method exists

                    return Ok(cabins); // 200 OK
                }
                catch (Exception ex)
                {
                    // Log the exception details (not shown here)
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
                }
            }

            /// <summary>
            /// Creates a new cabin.
            /// </summary>
            /// <param name="cabin">The cabin to create.</param>
            /// <returns>The created cabin.</returns>
            /// <response code="201">Returns the created cabin</response>
            /// <response code="400">If the cabin is invalid</response>
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> CreateCabinAsync([FromBody] Cabin cabin)
            {
                if (cabin == null)
                {
                    return BadRequest("Cabin object is null"); // 400 Bad Request
                }

                try
                {
                    var createdCabin = await _cabinRepository.AddCabinAsync(cabin); // Assuming this method exists
                    return CreatedAtAction(nameof(GetCabinByIdAsync), new { id = createdCabin.Id }, createdCabin); // 201 Created
                }
                catch (Exception ex)
                {
                    // Log the exception details (not shown here)
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
                }
            }

            /// <summary>
            /// Updates an existing cabin.
            /// </summary>
            /// <param name="id">The ID of the cabin to update.</param>
            /// <param name="cabin">The updated cabin data.</param>
            /// <returns>204 No Content if successful, otherwise 400 or 404.</returns>
            /// <response code="204">If the cabin was updated successfully</response>
            /// <response code="400">If the cabin data is invalid</response>
            /// <response code="404">If the cabin is not found</response>
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> UpdateCabinAsync(int id, [FromBody] Cabin cabin)
            {
                if (cabin == null)
                {
                    return BadRequest("Cabin object is null"); // 400 Bad Request
                }

                try
                {
                    var existingCabin = await _cabinRepository.GetCabinByIdAsync(id);

                    if (existingCabin == null)
                    {
                        return NotFound(); // 404 Not Found
                    }

                    await _cabinRepository.UpdateCabinAsync(id, cabin); // Assuming this method exists

                    return NoContent(); // 204 No Content
                }
                catch (Exception ex)
                {
                    // Log the exception details (not shown here)
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
                }
            }

            /// <summary>
            /// Deletes a cabin by its ID.
            /// </summary>
            /// <param name="id">The ID of the cabin to delete.</param>
            /// <returns>204 No Content if successful, otherwise 404 or 500.</returns>
            /// <response code="204">If the cabin was deleted successfully</response>
            /// <response code="404">If the cabin is not found</response>
            /// <response code="500">If there is an internal server error</response>
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> DeleteCabinAsync(int id)
            {
                try
                {
                    var existingCabin = await _cabinRepository.GetCabinByIdAsync(id);

                    if (existingCabin == null)
                    {
                        return NotFound(); // 404 Not Found
                    }

                    await _cabinRepository.DeleteCabinAsync(id); // Assuming this method exists

                    return NoContent(); // 204 No Content
                }
                catch (Exception ex)
                {
                    // Log the exception details (not shown here)
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
                }
            }
        }
    }




