using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TestApi.Models;
using TestApi.Models.Repository;

namespace TestApi.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IDataRepository<OwnerData> _dataRepository;
        public OwnerController(IDataRepository<OwnerData> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/owner
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<OwnerData> owners = _dataRepository.GetAll();
            return Ok(owners);
        }

        // GET: api/owner/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            OwnerData owner = _dataRepository.Get(id);

            if (owner == null)
            {
                return NotFound("The owner record couldn't be found.");
            }

            return Ok(owner);
        }

        
        // POST: api/Owner

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        public IActionResult Post([FromBody]JObject jObject)
        {
            OwnerData od = new OwnerData();
            od.OwnerName = Convert.ToString(jObject.SelectToken("OwnerName"));
            od.OwnerEmail = Convert.ToString(jObject.SelectToken("OwnerEmail"));
            od.OwnerContact = Convert.ToInt64(jObject.SelectToken("OwnerContact"));
            od.Ownerpass = Convert.ToString(jObject.SelectToken("Ownerpass"));
            //if (owner  == null)
            //{
            //    return BadRequest("Owner is null.");
            //}

            _dataRepository.Add(od);
            return CreatedAtRoute(
                  "Get",
                  new { Id = od.OwnerEmail },
                  od);
            
        }

        // PUT: api/owner/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] OwnerData owner)
        {
            if (owner == null)
            {
                return BadRequest("Owner is null.");
            }

            OwnerData ownerToUpdate = _dataRepository.Get(id);
            if (ownerToUpdate == null)
            {
                return NotFound("The Owner record couldn't be found.");
            }

            _dataRepository.Update(ownerToUpdate, owner);
            return NoContent();
        }

        // DELETE: api/Owner/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            OwnerData owner = _dataRepository.Get(id);
            if (owner == null)
            {
                return NotFound("The Owner record couldn't be found.");
            }

            _dataRepository.Delete(owner);
            return NoContent();
        }
    }
}
