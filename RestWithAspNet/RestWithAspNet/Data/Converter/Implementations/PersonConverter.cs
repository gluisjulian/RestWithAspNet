using RestWithAspNet.Data.Converter.Contract;
using RestWithAspNet.Data.Vo;
using RestWithAspNet.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNet.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        //PersonVO para Person
        public Person Parse(PersonVO origem)
        {
            if (origem == null) return null;
            return new Person
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };
        }

        public List<Person> Parse(List<PersonVO> origem)
        {
            if(origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }



        //Person para PersonVO
        public PersonVO Parse(Person origem)
        {
            if (origem == null) return null;
            return new PersonVO
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };
        }

        public List<PersonVO> Parse(List<Person> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
