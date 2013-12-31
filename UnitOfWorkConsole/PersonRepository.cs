using System;
using System.Collections.Generic;
using PetaPoco;

namespace UnitOfWorkConsole
{
    public interface IPersonRepository
    {
        IList<Person> GetAllPeople();
        void InsertNewPerson(IUnitOfWork unitOfWork, Person person);
        void PromotePerson(IUnitOfWork unitOfWork, Person person);
    }
    
    public class PersonRepository : IPersonRepository
    {
        public IList<Person> GetAllPeople()
        {
            return new Database("sqlserverce").Fetch<Person>("SELECT * FROM Person");
        }

        public void InsertNewPerson(IUnitOfWork unitOfWork, Person person)
        {
            if (person.LastUpdated == DateTime.MinValue)
            {
                person.LastUpdated = DateTime.Now;
            }
            
            unitOfWork.Db.Insert(person);    
        }

        public void PromotePerson(IUnitOfWork unitOfWork, Person person)
        {
            person.IsLeader = true;
            person.LastUpdated = DateTime.Now;
            unitOfWork.Db.Update(person);    
        }
    }
}