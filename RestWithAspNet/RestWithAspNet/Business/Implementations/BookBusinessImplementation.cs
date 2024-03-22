using AutoMapper;
using RestWithAspNet.Data.Converter.Implementations;
using RestWithAspNet.Data.DTO;
using RestWithAspNet.Data.Vo;
using RestWithAspNet.Model;
using RestWithAspNet.Repository.Generic;
using System.Collections.Generic;

namespace RestWithAspNet.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;
        private IMapper _mapper;

        public BookBusinessImplementation(IRepository<Book> repository,IMapper mapper)
        {
            _repository = repository;
            _converter = new BookConverter();
            _mapper = mapper;

        }

        public List<BookDTO> FindAll()
        {
            var book = _repository.FindAll();
            var bookDto = _mapper.Map<List<BookDTO>>(book);
            return bookDto;

            //return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Create(BookVO bookVo)
        {
            var bookEntity = _converter.Parse(bookVo);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }


        public BookVO Update(BookVO bookVo)
        {
            var bookEntity = _converter.Parse(bookVo);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }


        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
