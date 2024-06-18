using PeopleMvcApp.Models;

public interface IPeopleService
{
    Person Add(CreatePersonViewModel person);
    List<Person> All();
    List<Person> Search(string search);
    Person FindById(int id);
    bool Edit(int id, CreatePersonViewModel person);
    bool Remove(int id);
}