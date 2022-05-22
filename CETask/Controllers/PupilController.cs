using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CETask.Interfaces;
using CETask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CETask.Controllers
{
    [Route("api/[controller]")]
    public class PupilController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;

        public PupilController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var Pupils = await _cosmosDbService.GetMultiplePupilsAsync();

            if (Pupils != null)
            return Ok(Pupils);

            return NotFound();
        }

        [HttpGet("{id}")]
        public void Get(string id)
        {
           
        }

        [HttpPost]
        public void Post(Pupil pupil)
        {
          
             _cosmosDbService.AddPupilsync(pupil);

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
