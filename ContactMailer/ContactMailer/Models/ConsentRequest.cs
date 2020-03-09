using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMailer.Models
{
    public class ConsentRequest
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
        public string Template { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public ConsentRequestStatus Status { get; set; }

    }
}
