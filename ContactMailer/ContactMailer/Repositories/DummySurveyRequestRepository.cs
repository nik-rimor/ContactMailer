using ContactMailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMailer.Repositories
{
    public class DummySurveyRequestRepository : ISurveyRequestRepository
    {
        private Dictionary<Guid, SurveyRequest> _requersts = new Dictionary<Guid, SurveyRequest>()
        {
            [Guid.Parse("24a29891-0f4b-490c-94ab-340229a836e9")] = new SurveyRequest
            {
                Id = Guid.Parse("24a29891-0f4b-490c-94ab-340229a836e9"),
                EmailAddress = "someone@somewhere.net",
                FullName = "John Doe",
                SubmissionDate = null,
                Status = SurveyRequestStatus.Pending,
            },
            [Guid.Parse("bb9072aa-1a08-457a-8ecb-e80807527e44")] = new SurveyRequest
            {
                Id = Guid.Parse("bb9072aa-1a08-457a-8ecb-e80807527e44"),
                EmailAddress = "tester1@tester.test",
                FullName = "Mpampis Flou",
                SubmissionDate = null,
                Status = SurveyRequestStatus.Pending,
            },
        };

        public SurveyRequest Get(Guid id)
        {
            _requersts.TryGetValue(id, out SurveyRequest req);
            return req;
        }

        public SurveyRequest GetByEmailAddress(string emailAddress)
        {
            foreach(KeyValuePair<Guid, SurveyRequest> item in _requersts)
            {
                if (item.Value.EmailAddress == emailAddress)
                    return item.Value;
            }
            return null;
        }

        public IList<SurveyRequest> GetByStatus(SurveyRequestStatus status)
        {
            IList<SurveyRequest> requestsList = new List<SurveyRequest>();
            foreach(KeyValuePair<Guid, SurveyRequest> item in _requersts)
            {
                if (item.Value.Status == status)
                    requestsList.Add(item.Value);                
            }
            return requestsList;

        }

        public bool Update(SurveyRequest req)
        {
            try
            {
                _requersts[req.Id] = req;
                return true;
            }
            catch {
                return false;
            }

        }

        public bool Insert(SurveyRequest req)
        {
            try
            {
                _requersts.Add(req.Id, req);
                return true;
            }
            catch
            {
                return false;
            }            
        }

        public bool Delete(SurveyRequest req)
        {
            try
            {
                _requersts.Remove(req.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
