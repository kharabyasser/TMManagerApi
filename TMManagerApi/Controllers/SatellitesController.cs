using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TMManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TMManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatellitesController : ControllerBase
    {
        private readonly SatelliteContext _context;

        public SatellitesController(SatelliteContext context) => _context = context;

        //GET:      api/satellites
        //public ActionResult<IEnumerable<OnlineSatellite>> GetSatellites()
        [HttpGet]
        public string GetSatellites()
        {
            //return _context.Satellites;
            return "Hello";
        }

        //GET:      api/satellites/n
        [HttpGet("{id}")]
        public ActionResult<OnlineSatellite> GetSatelliteItem(int id)
        {
            var satelliteItem = _context.Satellites.Find(id);

            if (satelliteItem == null)
                return NotFound();

            return satelliteItem;
        }

        //POST:     api/satellites
        [HttpPost]
        public ActionResult<OnlineSatellite> PostSatelliteItem(OnlineSatellite satellite)
        {
            _context.Satellites.Add(satellite);
            _context.SaveChanges();

            return CreatedAtAction("GetSatelliteItem", new OnlineSatellite { Id = satellite.Id }, satellite);
        }


        //PUT:      api/satellites/n
        [HttpPut("{id}")]
        public ActionResult PutSatelliteItem(int id, OnlineSatellite satellite)
        {
            if (id != satellite.Id)
                return BadRequest();

            _context.Entry(satellite).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //Delete:       api/satellites/n
        [HttpDelete("{id}")]
        public ActionResult<OnlineSatellite> DeleteSatellitesItem(int id)
        {
            var satelliteItem = _context.Satellites.Find(id);
            if (satelliteItem == null)
                return NotFound();

            _context.Satellites.Remove(satelliteItem);
            _context.SaveChanges();

            return satelliteItem;
        }
    }
}