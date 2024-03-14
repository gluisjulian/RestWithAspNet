using RestWithAspNet.Model;
using RestWithAspNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNet.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private readonly MySqlContext _context;

        public PersonRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }


        public List<Person> FindAll()
        {
            try
            {
                var persons = _context.Persons.ToList();
                return persons;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Person FindById(long id)
        {
            try
            {
                var person = _context.Persons.FirstOrDefault(x => x.Id == id);
                return person;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return person;
        }


        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(x => x.Id.Equals(person.Id));
            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            return person;
        }

        public void Delete(long id)
        {
            try
            {
                var result = _context.Persons.FirstOrDefault(x => x.Id == id);
                _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public bool Exists(long id)
        {
            return _context.Persons.Any(x => x.Id.Equals(id));
        }

    }
}
