using RestWithAspNet.Model;
using System.Collections.Generic;

namespace RestWithAspNet.Repository
{
    public interface IBookRepository
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Create(Book person);
        Book Update(Book person);
        void Delete(long id);
        bool Exists(long id);
    }
}
