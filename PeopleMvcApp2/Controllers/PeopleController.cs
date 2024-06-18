using Microsoft.AspNetCore.Mvc;
using PeopleMvcApp.Data;
using PeopleMvcApp.Models;

public class PeopleController : Controller
{
    private readonly IPeopleService _peopleService;

    public PeopleController(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    public IActionResult Index(string searchString)
    {
        var viewModel = new PeopleViewModel();
        if (!string.IsNullOrEmpty(searchString))
        {
            viewModel.People = _peopleService.Search(searchString);
            viewModel.SearchString = searchString;
        }
        else
        {
            viewModel.People = _peopleService.All();
        }
        return View(viewModel);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreatePersonViewModel person)
    {
        if (!ModelState.IsValid)
        {
            return View(person);  // Visa vyn med felmeddelanden om modellen inte är giltig
        }

        _peopleService.Add(person);  // Lägg till person i service

        // Redirect till Index-action i samma controller för att visa uppdaterad lista
        return RedirectToAction("Index");
    }


    public IActionResult Details(int id)
    {
        var person = _peopleService.FindById(id);
        if (person == null)
        {
            return NotFound();
        }
        return View(person);
    }

    public IActionResult Delete(int id)
    {
        var success = _peopleService.Remove(id);
        if (!success)
        {
            return NotFound();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Edit(int id, EditPersonViewModel editedPerson)
    {
        if (id != editedPerson.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(editedPerson);
        }


        var createPersonViewModel = new CreatePersonViewModel
        {
            Name = editedPerson.Name,
            PhoneNumber = editedPerson.PhoneNumber,
            City = editedPerson.City
        };

        var success = _peopleService.Edit(id, createPersonViewModel);
        if (!success)
        {
            return NotFound();
        }

        return RedirectToAction("Index");
    }



}


