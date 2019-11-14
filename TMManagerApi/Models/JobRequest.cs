using System;
using System.Collections.Generic;

namespace TMManagerApi.Models
{
    public class JobRequest
    {
        public JobRequest() => this.JobResponses = new List<JobResponse>();
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public int Status { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string JobDetails { get; set; }
        public List<JobResponse> JobResponses { get; set; }
    }
}
