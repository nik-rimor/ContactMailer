using ContactMailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMailer.Repositories
{
    public class DummyConsentRequestRepository : IConsentRequestRepository
    {
        private Dictionary<Guid, ConsentRequest> _requests = new Dictionary<Guid, ConsentRequest>()
        {
            [Guid.Parse("24a29891-0f4b-490c-94ab-340229a836e9")] = new ConsentRequest
            {
                Id = Guid.Parse("24a29891-0f4b-490c-94ab-340229a836e9"),
                EmailAddress = "someone@somewhere.net",
                FullName = "John Doe",
                SubmissionDate = null,
                Status = ConsentRequestStatus.Pending,
            },
            [Guid.Parse("bb9072aa-1a08-457a-8ecb-e80807527e44")] = new ConsentRequest
            {
                Id = Guid.Parse("bb9072aa-1a08-457a-8ecb-e80807527e44"),
                EmailAddress = "tester1@tester.test",
                FullName = "Mpampis Flou",
                SubmissionDate = null,
                Status = ConsentRequestStatus.Pending,
            },
        };

        public ConsentRequest Get(Guid id)
        {
             _requests.TryGetValue(id, out ConsentRequest req);
            return req;
        }

        public ConsentRequest GetByEmailAddress(string emailAddress)
        {
            return _requests.Values
                    .Where(v => v.EmailAddress == emailAddress)
                    .FirstOrDefault();

        }
        public IList<ConsentRequest> GetAll()
        {
            return _requests.Values.ToList();
        }

        public IList<ConsentRequest> GetByStatus(ConsentRequestStatus status)
        {
            return _requests.Values
                    .Where(v => v.Status == status)
                    .ToList();
        }

        public bool Update(ConsentRequest req)
        {
            return _requests.TryAdd(req.Id, req);
        }

        public ConsentRequest Insert(ConsentRequest req)
        {
            try
            {
                if (this.GetByEmailAddress(req.EmailAddress) != null)
                    throw new InvalidOperationException("Email address " + req.EmailAddress + " already exists");

                Guid id;
                do
                {
                    id = Guid.NewGuid();
                } while (_requests.ContainsKey(id));

                ConsentRequest newreq = new ConsentRequest()
                {
                    Id = id,
                    FullName = req.FullName,
                    EmailAddress = req.EmailAddress,
                    Template = req.Template,
                    Status = req.Status,
                    SubmissionDate = null,
                };
                _requests.Add(id, newreq);

                return newreq;
            }
            catch (Exception e)
            {

                return null;
            }            
        }

        public bool Delete(ConsentRequest req)
        {
            try
            {
                _requests.Remove(req.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
