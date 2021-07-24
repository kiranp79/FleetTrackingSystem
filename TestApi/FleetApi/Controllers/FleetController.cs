using System.Collections.Generic;
using FleetApi.Models;
using FleetApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{

    [Route("api/fleet")]
    [ApiController]
    public class FleetController : ControllerBase
    {
        private readonly IDataRepository<FleetData> _dataRepository;
        public FleetController(IDataRepository<FleetData> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/fleet
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<FleetData> fleet = _dataRepository.GetAll();
            return Ok(fleet);
        }

        // GET: api/fleet/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            FleetData fleet = _dataRepository.Get(id);

            if (fleet == null)
            {
                return NotFound("The fleet record couldn't be found.");
            }

            return Ok(fleet);
        }

        // POST: api/fleet
        [HttpPost]
        public IActionResult Post([FromBody] FleetData fleet)
        {
            if (fleet == null)
            {
                return BadRequest("Fleet is null.");
            }

            _dataRepository.Add(fleet);
            return CreatedAtRoute(
                  "Get",
                  new { Id = fleet.FleetID },
                  fleet);
        }

        // PUT: api/fleet/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] FleetData fleet)
        {
            if (fleet == null)
            {
                return BadRequest("Fleet is null.");
            }

            FleetData fleetToUpdate = _dataRepository.Get(id);
            if (fleetToUpdate == null)
            {
                return NotFound("The Fleet record couldn't be found.");
            }

            _dataRepository.Update(fleetToUpdate, fleet);
            return NoContent();
        }

        // DELETE: api/Owner/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            FleetData fleet = _dataRepository.Get(id);
            if (fleet == null)
            {
                return NotFound("The Fleet record couldn't be found.");
            }

            _dataRepository.Delete(fleet);
            return NoContent();
        }
    }
}
