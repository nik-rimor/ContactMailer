using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMailer.Models
{
    public class ConsentTemplate
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string EmailHeader { get; set; }
        public string EnailFooter { get; set; }
        public string EmailMessage { get; set; }
        public string FormHeader { get; set; }
        public string FormFooter { get; set; }
        public string FormMessage { get; set; }

    }
}
