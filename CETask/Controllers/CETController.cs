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
    public class CETController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;

        public CETController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _cosmosDbService.GetMultipleAsync("SELECT * FROM c"));
        }

        [HttpGet("{id}")]
        public void Get(string id)
        {
           
        }

        [HttpPost]
        public void Post(string EntryID,string id,string Type,string Name,string Grade,string Subject)
        {
            Dictionary<string, string> _ValuesProperties = new Dictionary<string, string>();
            if (Type != "Teacher" && Type != "Pupil")
                return;

            if (Type=="Teacher")
                _ValuesProperties["Subject"]=Subject;
            _ValuesProperties["Name"] = Name;
            _ValuesProperties["Grade"] = Grade;

            Item Item = new Item() { id = id, EntryID = EntryID, Type = Type, ValuesProperties = _ValuesProperties };
             _cosmosDbService.AddAsync(Item);

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
