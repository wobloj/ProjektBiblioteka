using Microsoft.AspNetCore.Mvc;
using ProjektBiblioteka.Models.Books;
using ProjektBiblioteka.Models.People;
using ProjektBiblioteka.Services.People;

namespace ProjektBiblioteka.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly IPeopleService _peopleService;

        public PeopleController(ILogger<PeopleController> logger, IPeopleService booksService)
        {
            _logger = logger;
            _peopleService = booksService;
        }

        public IActionResult Index()
        {
            var model = new PersonViewModel()
            {
                People = _peopleService.GetPeople()
            };
            return View(model);
        }

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(string FirstName, string LastName, string Email, string Phone)
        {
            if (ModelState.IsValid)
            {
                _peopleService.AddPerson(FirstName, LastName, Email, Phone);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult RemoveBook(int Id)
        {
            _peopleService.DeletePerson(Id);
            return RedirectToAction("Index");
        }

        public IActionResult EditPersonData(int Id, string FirstName, string LastName, string Email, string Phone)
        {
            var model = new EditPersonDataViewModel()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditThisPersonData(int Id, string FirstName, string LastName, string Email, string Phone)
        {
            if (ModelState.IsValid)
            {
                _peopleService.UpdatePersonData(Id, FirstName, LastName, Email, Phone);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
