using ContactMailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMailer.Repositories
{
    interface ISurveyRequestRepository
    {
        SurveyRequest Get(Guid id);

        SurveyRequest GetByEmailAddress(string emailAddress);

        IList<SurveyRequest> GetByStatus(SurveyRequestStatus status);

        bool Update(SurveyRequest req);

        bool Insert(SurveyRequest req);

        bool Delete(SurveyRequest req);
    }
}
