using PeopleMvcApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PeopleMvcApp.Data
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _people = new List<Person>
{
new Person { Id = 1, Name = "Alice", PhoneNumber = "111-111-1111", City = "Stockholm" },
new Person { Id = 2, Name = "Bob", PhoneNumber = "222-222-2222", City = "Gothenburg" },
new Person { Id = 3, Name = "Charlie", PhoneNumber = "333-333-3333", City = "Malmo" }
};


        private static int _idCounter = 4;

        public Person Create(Person person)
        {
            person.Id = GetNextId();
            _people.Add(person);
            return person;
        }


        public List<Person> Read()
        {
            return _people;
        }

        public Person Read(int id)
        {
            return _people.FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Person person)
        {
            var existingPerson = _people.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.PhoneNumber = person.PhoneNumber;
                existingPerson.City = person.City;
                return true;
            }
            return false;
        }

        public bool Delete(Person person)
        {
            var existingPerson = _people.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                _people.Remove(existingPerson);
                return true;
            }
            return false;
        }

        public int GetNextId()
        {
            return _idCounter++;

        }

        public int NextId()
        {
            return _idCounter;
        }
    }
}