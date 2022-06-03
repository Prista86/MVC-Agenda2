using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Agenda2.Models;
using MVC_Agenda2.DB;
using MVC_Agenda2.DB.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Agenda2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository repository;

        public HomeController(ILogger<HomeController> logger, Repository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Insert()
        {
            return View();
        }

        public IActionResult Agenda()
        {
            List<Person> persons = this.repository.GetPersons();
            List<PersonModel> model = new List<PersonModel>();
            foreach (Person p in persons)
                model.Add(new PersonModel()
                {
                    Nome = p.Nome,
                    Cognome = p.Cognome,
                    Email = p.IndirizzoEmail
                });
            return View(model);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
