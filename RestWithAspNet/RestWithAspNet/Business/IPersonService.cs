using RestWithAspNet.Data.Vo;
using System.Collections.Generic;

namespace RestWithAspNet.Business
{
    public interface IPersonBusiness
    {
        List<PersonVO> FindAll();
        PersonVO FindById(long id);
        PersonVO Create(PersonVO personVo);
        PersonVO Update(PersonVO personVo);
        void Delete(long id);
    }
}
