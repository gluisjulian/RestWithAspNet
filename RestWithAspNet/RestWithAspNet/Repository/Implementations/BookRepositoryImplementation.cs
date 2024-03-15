using RestWithAspNet.Model;
using RestWithAspNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNet.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private readonly MySqlContext _context;

        public BookRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return book;
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = _context.Books.SingleOrDefault(x => x.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            return book;
        }

        public void Delete(long id)
        {
            try
            {
                var result = _context.Books.FirstOrDefault(x => x.Id == id);
                _context.Books.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(x => x.Id.Equals(id));
        }
    }
}
