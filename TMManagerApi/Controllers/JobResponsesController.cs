using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TMManagerApi.Models;

namespace TMManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobResponsesController : ControllerBase
    {
        private readonly SatelliteContext _context;

        public JobResponsesController(SatelliteContext context) => _context = context;

        // GET:     api/jobresponses
        [HttpGet]
        public ActionResult<IEnumerable<JobResponse>> GetJobResponse()
        {
            try
            {
                var jobResponses = _context.JobResponses;
                if (jobResponses == null)
                    return NotFound();
                else
                    return jobResponses;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET:     api/jobresponses/n
        [HttpGet("{Id}")]
        public ActionResult<JobResponse> GetJobResponseItem(int Id)
        {
            try
            {
                var jobResponseItem = _context.JobResponses.Find(Id);
                if (jobResponseItem == null)
                    return NotFound();
                else
                    return jobResponseItem;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //POST:      api/jobresponses
        [HttpPost]
        public ActionResult<JobResponse> PostJobResponseItem(JobResponse jobResponse)
        {
            _context.JobResponses.Add(jobResponse);
            _context.SaveChanges();

            return CreatedAtAction("GetJobResponseItem", new JobResponse { Id = jobResponse.Id }, jobResponse);
        }

        //PUT:      api/jobresponse/n
        [HttpPut("{Id}")]
        public ActionResult PutJobResponse(int Id, JobResponse jobResponse)
        {
            if (Id != jobResponse.Id)
                return BadRequest();

            _context.Entry(jobResponse).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE:       api/jobresponse/n
        [HttpDelete("{Id}")]
        public ActionResult<JobResponse> DeleteJobResponseItem(int Id)
        {
            var jobResponseItem = _context.JobResponses.Find(Id);
            if (jobResponseItem == null)
                return NotFound();

            _context.JobResponses.Remove(jobResponseItem);
            _context.SaveChanges();

            return jobResponseItem;
        }
    }
}
