using ContactMailer.Data;
using ContactMailer.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMailer.Repositories
{
    public class LiteDbConsentRequestRepository : IConsentRequestRepository
    {
        private LiteDatabase _liteDb;

        public LiteDbConsentRequestRepository(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }


        public ConsentRequest Get(Guid id)
        {
            var result = _liteDb.GetCollection<ConsentRequest>("ConsentRequest")
                .Find(r => r.Id == id).FirstOrDefault();
            return result;
        }

        public ConsentRequest GetByEmailAddress(string emailAddress)
        {
            var result = _liteDb.GetCollection<ConsentRequest>("ConsentRequest")
                .Find(r => r.EmailAddress == emailAddress).FirstOrDefault();
            return result;
        }

        public IList<ConsentRequest> GetAll()
        {
            var result = _liteDb.GetCollection<ConsentRequest>("ConsentRequest")
                .FindAll().ToList();
            return result;
        }

        public IList<ConsentRequest> GetByStatus(ConsentRequestStatus status)
        {
            var result = _liteDb.GetCollection<ConsentRequest>("ConsentRequest")
                .Find(r => r.Status == status).ToList();
            return result;
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
                } while (_liteDb.GetCollection<ConsentRequest>("ConsentRequest").Count(Query.EQ("_id", id)) > 0);
                
                ConsentRequest newreq = new ConsentRequest()
                {
                    Id = id,
                    FullName = req.FullName,
                    EmailAddress = req.EmailAddress,
                    Template = req.Template,
                    Status = req.Status,
                    SubmissionDate = null,
                };
                if (_liteDb.GetCollection<ConsentRequest>("ConsentRequest").Insert(newreq) != null)
                {
                    return newreq;
                } else
                {
                    return null;
                }
            } catch
            {
                return null;
            }
        }

        public bool Update(ConsentRequest req)
        {
            try
            {
                return _liteDb.GetCollection<ConsentRequest>("ConsentRequest")
                    .Update(req);
            } catch
            {
                return false;
            }
        }
        public bool Delete(ConsentRequest req)
        {
            try
            {
                return _liteDb.GetCollection<ConsentRequest>("ConsentRequest")
                     .Delete(req.Id);
            } catch
            {
                return false;
            }
        }


    }
}
