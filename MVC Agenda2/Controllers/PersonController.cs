using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Agenda2.DB;
using MVC_Agenda2.DB.Entities;
using MVC_Agenda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Agenda2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly Repository repository;
        public PersonController(Repository repository)
        {
            this.repository = repository;
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonModel model)
        {
            Person person = new Person();
            person.Nome = model.Nome;
            person.Cognome = model.Cognome;
            person.NumeroCellulare = model.NumeroCellulare;
            person.IndirizzoEmail = model.IndirizzoEmail;

            this.repository.InsertPerson(person);
            return Ok();
        }
    }
}

