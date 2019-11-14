using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TMManagerApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace TMManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatellitesController : ControllerBase
    {
        private readonly SatelliteContext _context;

        public SatellitesController(SatelliteContext context) => _context = context;

        //GET:      api/satellites
        [HttpGet]
        public ActionResult<IEnumerable<OnlineSatellite>> GetSatellites()
        {
            try
            {
                var satllites = _context.Satellites;
                if (satllites == null)
                    return NotFound();
                else
                    return satllites;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //GET:      api/satellites/n
        [HttpGet("{fingerprint}")]
        public ActionResult<OnlineSatellite> GetSatelliteItem(string fingerprint)
        {
            try
            {
                var satelliteItem = _context.Satellites.Find(fingerprint);
                if (satelliteItem == null)
                    return NotFound();
                else
                    return satelliteItem;
            }
            catch (Exception)
            {
                return NotFound();

            }
        }

        //POST:     api/satellites
        [HttpPost]
        public ActionResult<OnlineSatellite> PostSatelliteItem(OnlineSatellite satellite)
        {
            _context.Satellites.Add(satellite);
            _context.SaveChanges();

            return CreatedAtAction("GetSatelliteItem", new OnlineSatellite { Fingerprint = satellite.Fingerprint }, satellite);
        }


        //PUT:      api/satellites/n
        [HttpPut("{fingerprint}")]
        public ActionResult PutSatelliteItem(string fingerPrint, OnlineSatellite satellite)
        {
            if (fingerPrint != satellite.Fingerprint)
                return BadRequest();

            _context.Entry(satellite).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //Delete:       api/satellites/n
        [HttpDelete("{fingerprint}")]
        public ActionResult<OnlineSatellite> DeleteSatellitesItem(string fingerPrint)
        {
            var satelliteItem = _context.Satellites.Find(fingerPrint);
            if (satelliteItem == null)
                return NotFound();

            _context.Satellites.Remove(satelliteItem);
            _context.SaveChanges();

            return satelliteItem;
        }
    }
}