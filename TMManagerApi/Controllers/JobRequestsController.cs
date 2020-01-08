using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TMGrpcServer;
using TMManagerApi.Models;

namespace TMManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequestsController : ControllerBase
    {
        private readonly SatelliteContext _context;

        public JobRequestsController(SatelliteContext context) => _context = context;

        // GET:     api/jobrequests
        [HttpGet]
        public ActionResult<IEnumerable<JobRequest>> GetJobRequests()
        {
            try
            {
                var jobRequests = _context.JobRequests;
                if (jobRequests == null)
                    return NotFound();
                else
                    return jobRequests;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET:     api/jobrequests/n
        [HttpGet("{Id}")]
        public ActionResult<JobRequest> GetJobRequestsItem(int Id)
        {
            try
            {
                var jobRequestItem = _context.JobRequests.Find(Id);
                if (jobRequestItem == null)
                    return NotFound();
                else
                    return jobRequestItem;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //POST:      api/jobrequests
        [HttpPost]
        public ActionResult<JobRequest> PostJobRequestItem(JobRequest jobRequest)
        {
            try
            {
                _context.JobRequests.Add(jobRequest);
                _context.SaveChanges();

                NotifyGrpc(jobRequest);

                return CreatedAtAction("GetJobRequestItem", new JobRequest { Id = jobRequest.Id }, jobRequest);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //PUT:      api/jobrequests/n
        [HttpPut("{Id}")]
        public ActionResult PutJobRequest(int Id, JobRequest jobRequest)
        {
            if (Id != jobRequest.Id)
                return BadRequest();

            _context.Entry(jobRequest).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE:       api/jobrequest/n
        [HttpDelete("{Id}")]
        public ActionResult<JobRequest> DeleteJobRequestItem(int Id)
        {
            var jobRequestItem = _context.JobRequests.Find(Id);
            if (jobRequestItem == null)
                return NotFound();

            _context.JobRequests.Remove(jobRequestItem);
            _context.SaveChanges();

            return jobRequestItem;
        }

        public async void NotifyGrpc(JobRequest jobRequest)
        {
            try
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var httpClient = new HttpClient(httpClientHandler);

                var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpClient = httpClient });
                var jobRequestStream = new JobRequestGrpc.JobRequestGrpcClient(channel);

                var model = new JobRequestGrpcLookupModel
                {
                    DeviceId = jobRequest.DeviceId,
                    JobType1 = jobRequest.JobType
                };

                await jobRequestStream.OnNewJobRequestGrpcAsync(model);
            }
            catch (Exception)
            {
                //Log to Azure.     
            }
        }
    }
}
