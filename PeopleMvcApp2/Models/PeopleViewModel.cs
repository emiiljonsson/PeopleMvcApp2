using System.Collections.Generic;

namespace PeopleMvcApp.Models
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; }
        public string SearchString { get; set; }
    }
}
