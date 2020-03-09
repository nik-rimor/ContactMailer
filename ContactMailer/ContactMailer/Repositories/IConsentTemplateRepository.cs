using ContactMailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMailer.Repositories
{
    interface IConsentTemplateRepository
    {
        public interface IConsentTemplateRepository
        {
            ConsentTemplate Get(string id);

            bool Update(ConsentTemplate template);

            IList<ConsentTemplate> GetAll();

            ConsentTemplate Insert(ConsentTemplate template);

        }

    }
}
