using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNet.Business;
using RestWithAspNet.Data.Vo;

namespace RestWithAspNet.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookBusiness.FindAll());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult Post([FromBody] BookVO bookVo)
        {
            if (bookVo == null) return NotFound();
            return Ok(_bookBusiness.Create(bookVo));
        }


        [HttpPut]
        public IActionResult Put([FromBody] BookVO bookVo)
        {
            if (bookVo == null) return NotFound();
            return Ok(_bookBusiness.Update(bookVo));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
