using RestWithAspNet.Model.Base;
using System.Collections.Generic;

namespace RestWithAspNet.Repository.Generic
{
    public interface IRepository <T> where T : BaseEntity
    {
        List<T> FindAll();
        T FindById(long id);
        T Create(T item);
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}
