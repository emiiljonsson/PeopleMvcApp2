using PeopleMvcApp.Models;
using System.Collections.Generic;

namespace PeopleMvcApp.Data
{
    public interface IPeopleRepo
    {
        Person Create(Person person);
        List<Person> Read();
        Person Read(int id);
        bool Update(Person person);
        bool Delete(Person person);
        int GetNextId();
        int NextId();
    }
}