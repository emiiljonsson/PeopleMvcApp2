using PeopleMvcApp.Data;
using PeopleMvcApp.Models;
using System;

public class PeopleService : IPeopleService
{
    private readonly IPeopleRepo _peopleRepo;


    public PeopleService(IPeopleRepo peopleRepo)
    {
        _peopleRepo = peopleRepo;
    }

    public Person Add(CreatePersonViewModel person)
    {
        // Map CreatePersonViewModel to Person
        var newPerson = new Person
        {
            Id = _peopleRepo.GetNextId(),  // Använd GetNextId för att hämta nästa tillgängliga ID
            Name = person.Name,
            PhoneNumber = person.PhoneNumber,
            City = person.City
        };

        // Lägg till den nya personen i repository
        _peopleRepo.Create(newPerson);

        return newPerson;
    }



    public List<Person> All()
    {
        return _peopleRepo.Read();
    }


    public List<Person> Search(string search)
    {
        return _peopleRepo.Read().Where(p =>
            p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            p.City.Contains(search, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public Person FindById(int id)
    {
        return _peopleRepo.Read(id);
    }

    public bool Edit(int id, CreatePersonViewModel person)
    {
        var existingPerson = _peopleRepo.Read(id);
        if (existingPerson == null)
            return false;

        existingPerson.Name = person.Name;
        existingPerson.PhoneNumber = person.PhoneNumber;
        existingPerson.City = person.City;

        return _peopleRepo.Update(existingPerson);
    }

    public bool Remove(int id)
    {
        var personToRemove = _peopleRepo.Read(id);
        if (personToRemove == null)
            return false;

        return _peopleRepo.Delete(personToRemove);
    }
}