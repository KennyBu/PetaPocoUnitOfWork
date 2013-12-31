using System;
using System.Collections.Generic;

namespace UnitOfWorkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var personRepo = new PersonRepository();
            var people = personRepo.GetAllPeople();

            DisplayPeople(people);

            Console.WriteLine("Type in a name:");
            var name = Console.ReadLine();
            Console.WriteLine("Type in an email:");
            var email = Console.ReadLine();

            var newPerson = new Person
                {
                    Name = name,
                    Email = email
                };

            var unitOfWorkProvider = new PetaPocoUnitOfWorkProvider();
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {

                personRepo.InsertNewPerson(uow, newPerson);
                personRepo.PromotePerson(uow,newPerson);

                uow.Commit();
            }

            people = personRepo.GetAllPeople();

            DisplayPeople(people);

            Console.WriteLine("");
            Console.WriteLine("The person you entered should now be displayed.");
            Console.WriteLine("");
            Console.WriteLine("Press a key to enter another user and test the rollback.");
            Console.WriteLine("");
            Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Type in a name:");
            name = Console.ReadLine();
            Console.WriteLine("Type in an email:");
            email = Console.ReadLine();
            newPerson = new Person
            {
                Name = name,
                Email = email
            };

            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {

                personRepo.InsertNewPerson(uow, newPerson);
                personRepo.PromotePerson(uow, newPerson);
            }

            people = personRepo.GetAllPeople();

            DisplayPeople(people);
            Console.WriteLine("");
            Console.WriteLine("The person you entered should NOT be displayed.");
            Console.ReadLine();
        }

        private static void DisplayPeople(IEnumerable<Person> people)
        {
            Console.WriteLine("List of People");
            Console.WriteLine("--------------");

            foreach (var person in people)
            {
                Console.WriteLine("Name: \t {0} ", person.Name);
                Console.WriteLine("Email: \t {0} ", person.Email);
                Console.WriteLine("Is Leader?: \t {0}", person.IsLeader);
                Console.WriteLine("Last Updated: \t {0}", person.LastUpdated);
                Console.WriteLine("");
            }
        }
    }
}
