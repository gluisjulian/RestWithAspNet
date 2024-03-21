using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNet.Model;
using RestWithAspNet.Business;
using RestWithAspNet.Data.Vo;

namespace RestWithAspNet.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personBusiness.FindAll());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = _personBusiness.FindById(id);
            if(person != null)
            {
                return Ok(person);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult Post([FromBody] PersonVO personVo)
        {
            if (personVo == null) return NotFound();
            return Ok(_personBusiness.Create(personVo));
        }


        [HttpPut]
        public IActionResult Put([FromBody] PersonVO personVo)
        {
            if (personVo == null) return NotFound();
            return Ok(_personBusiness.Update(personVo));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }

    }
}
