using RestWithAspNet.Data.Converter.Contract;
using RestWithAspNet.Data.Vo;
using RestWithAspNet.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNet.Data.Converter.Implementations
{
    public class BookConverter : IParser<Book, BookVO>, IParser<BookVO, Book>
    {

        //Book para BookVO
        public BookVO Parse(Book origem)
        {
            if(origem == null) return null;
            return new BookVO
            {
                Id = origem.Id,
                Author = origem.Author,
                Title = origem.Title,
                Price = origem.Price,
                LaunchDate = origem.LaunchDate,
            };
        }

        public List<BookVO> Parse(List<Book> origem)
        {
            if( origem == null ) return null;
            return origem.Select(item => Parse(item)).ToList();
        }




        //BookVO para Book
        public Book Parse(BookVO origem)
        {
            if (origem == null) return null;
            return new Book
            {
                Id = origem.Id,
                Author = origem.Author,
                Title = origem.Title,
                Price = origem.Price,
                LaunchDate = origem.LaunchDate,
            };
        }

        public List<Book> Parse(List<BookVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
