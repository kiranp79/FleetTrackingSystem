using System.Collections.Generic;
using LocationApi.Models;
using LocationApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LocationApi.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IDataRepository<LocationInfo> _dataRepository;
        public LocationController(IDataRepository<LocationInfo> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/fleet
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<LocationInfo> location = _dataRepository.GetAll();
            return Ok(location);
        }

        // GET: api/fleet/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            LocationInfo location = _dataRepository.Get(id);

            if (location == null)
            {
                return NotFound("The Location record couldn't be found.");
            }

            return Ok(location);
        }

        // POST: api/fleet
        [HttpPost]
        public IActionResult Post([FromBody] LocationInfo location)
        {
            if (location == null)
            {
                return BadRequest("Fleet is null.");
            }

            _dataRepository.Add(location);
            return CreatedAtRoute(
                  "Get",
                  new { Id = location.LocationID },
                  location);
        }

        // PUT: api/fleet/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] LocationInfo location)
        {
            if (location == null)
            {
                return BadRequest("Fleet is null.");
            }

            LocationInfo locationToUpdate = _dataRepository.Get(id);
            if (locationToUpdate == null)
            {
                return NotFound("The Location record couldn't be found.");
            }

            _dataRepository.Update(locationToUpdate, location);
            return NoContent();
        }

        // DELETE: api/Owner/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            LocationInfo location = _dataRepository.Get(id);
            if (location == null)
            {
                return NotFound("The Location record couldn't be found.");
            }

            _dataRepository.Delete(location);
            return NoContent();
        }
    }
}
