using RestWithAspNet.Data.Vo;
using System.Collections.Generic;

namespace RestWithAspNet.Business
{
    public interface IBookBusiness
    {
        List<BookVO> FindAll();
        BookVO FindById(long id);
        BookVO Create(BookVO bookVo);
        BookVO Update(BookVO bookVo);
        void Delete(long id);
    }
}
