using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactMailer.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactMailer.Areas.Consent.Controllers
{
    [Area("Consent")]
    public class FormController : Controller
    {
        private readonly IConsentRequestRepository _repo;

        public FormController(IConsentRequestRepository repo)
        {
            _repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
