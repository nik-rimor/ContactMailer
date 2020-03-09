using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactMailer.Models;
using ContactMailer.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactMailer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ConsentRequestController : Controller
    {
        private readonly IConsentRequestRepository _repo;

        public ConsentRequestController(IConsentRequestRepository repo )
        {
             _repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<ConsentRequest> requestList = _repo.GetAll();
            return View(requestList);
        }
    }
}
