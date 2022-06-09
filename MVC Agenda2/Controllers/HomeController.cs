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
            //Person person = new Person()
            //{
            //    Nome = "Insert NomeA",
            //    Cognome = "Insert CognomeA",
            //    NumeroCellulare = "NumeroA",
            //    IndirizzoEmail = "IndirizzoA"
            //};
            //this.repository.InsertPerson(person);
            //return View(new PersonModel()
            //{
            //    Nome = person.Nome,
            //    Cognome = person.Cognome,
            //    Email = person.IndirizzoEmail
            //});
            return View();
        }
        public IActionResult Search()
        {
            List<Person> persons = this.repository.GetPersonWithFilter("luca");
            List<PersonModel> model = new List<PersonModel>();
            foreach (Person p in persons)
                model.Add(new PersonModel()
                {
                    Nome = p.Nome,
                    Cognome = p.Cognome
                });
            return View(model);
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
                    IndirizzoEmail = p.IndirizzoEmail                    
                }); ;
            return View(model);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
