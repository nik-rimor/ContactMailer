using ContactMailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMailer.Repositories
{
    public interface IConsentRequestRepository
    {
        ConsentRequest Get(Guid id);

        ConsentRequest GetByEmailAddress(string emailAddress);

        IList<ConsentRequest> GetAll();

        IList<ConsentRequest> GetByStatus(ConsentRequestStatus status);

        bool Update(ConsentRequest req);

        ConsentRequest Insert(ConsentRequest req);

        bool Delete(ConsentRequest req);
    }
}
