using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafariApi.Models;

namespace SafariApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SeenAnimalsController : ControllerBase
  {

    [HttpGet]
    // https://localhost:5001/api/SeenAnimals 
    public IEnumerable<SeenAnimals> Get()
    {
      var db = new SeenAnimalsContext();
      return db.SeenAnimals.OrderBy(o => o.CountOfTimesSeen);
    }
    [HttpGet("{location}")]
    public IEnumerable<SeenAnimals> GetbyLocation(string location)
    {
      var db = new SeenAnimalsContext();
      return db.SeenAnimals.Where(w => w.LocationOfLastSeen.ToLower() == location.ToLower());
    }
    [HttpPost]

    public ActionResult<SeenAnimals> Post([FromBody] SeenAnimals seenAnimals)
    {
      var db = new SeenAnimalsContext();
      db.SeenAnimals.Add(seenAnimals);
      db.SaveChanges();
      return seenAnimals;
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      var db = new SeenAnimalsContext();
      var animal = db.SeenAnimals.FirstOrDefault(a => a.Id == id);
      if (animal == null)
      {
        return NotFound();
      }
      db.SeenAnimals.Remove(animal);
      db.SaveChanges();
      return Ok();
    }
    [HttpPut("{id}")]
    public ActionResult<SeenAnimals> Put([FromRoute] int id, [FromBody] SeenAnimals updatedData)
    {
      var db = new SeenAnimalsContext();
      var seenAnimals = db.SeenAnimals.FirstOrDefault(animals => animals.Id == id);
      seenAnimals.Species = updatedData.Species;
      seenAnimals.CountOfTimesSeen = updatedData.CountOfTimesSeen;
      seenAnimals.LocationOfLastSeen = updatedData.LocationOfLastSeen;
      db.SaveChanges();
      return updatedData;

    }
  }

}