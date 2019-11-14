using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMManagerApi.Models
{
    public class JobResponse
    {
        public int Id { get; set; }
        public DateTime ResponseDateTime { get; set; }
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; }
        [ForeignKey("JobRequest")]
        public int JobRequestId { get; set; }
        public JobRequest JobRequest { get; set; }
    }
}
