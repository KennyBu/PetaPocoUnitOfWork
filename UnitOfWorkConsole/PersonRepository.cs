using System;
using System.Collections.Generic;
using PetaPoco;

namespace UnitOfWorkConsole
{
    public interface IPersonRepository
    {
        IList<Person> GetAllPeople();
        void InsertNewPerson(Person person);
        void PromotePerson(Person person);
    }

    public class PersonRepository : PetaPocoUnitOfWork, IPersonRepository
    {
        
        private readonly Database _database;

        public PersonRepository(Database database)
            :base(database)
        {
            _database = database;
        }

        public IList<Person> GetAllPeople()
        {
            return _database.Fetch<Person>("SELECT * FROM Person");
        }

        public void InsertNewPerson(Person person)
        {
            if (person.LastUpdated == DateTime.MinValue)
            {
                person.LastUpdated = DateTime.Now;
            }
            
            _database.Insert(person);    
        }

        public void PromotePerson(Person person)
        {
            person.IsLeader = true;
            person.LastUpdated = DateTime.Now;
           _database.Update(person);    
        }
    }
}