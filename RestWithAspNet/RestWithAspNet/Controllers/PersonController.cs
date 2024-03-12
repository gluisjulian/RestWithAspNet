﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNet.Model;
using RestWithAspNet.Services;

namespace RestWithAspNet.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.FindAll());

        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = _personService.FindById(id);
            if(person != null)
            {
                return Ok(person);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return NotFound();
            return Ok(_personService.Create(person));
        }


        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return NotFound();
            return Ok(_personService.Create(person));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }

    }
}
