using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektBiblioteka.Models.Books;
using ProjektBiblioteka.Models.Borrow;
using ProjektBiblioteka.Models.People;
using ProjektBiblioteka.Services.Books;
using ProjektBiblioteka.Services.Borrow;
using ProjektBiblioteka.Services.People;

namespace ProjektBiblioteka.Controllers
{
    public class BorrowController : Controller
    {
        private readonly ILogger<BorrowController> _logger;
        private readonly IBorrowService _borrowService;
        private readonly IBooksService _bookService;
        private readonly IPeopleService _peopleService;

        public BorrowController(ILogger<BorrowController> logger, IBorrowService borrowService, IBooksService bookService, IPeopleService peopleService)
        {
            _logger = logger;
            _borrowService = borrowService;
            _bookService = bookService;
            _peopleService = peopleService;
        }
        public IActionResult Index()
        {
            var model = new BorrowViewModel()
            {
                BorrowList = _borrowService.GetBorrows(),
                BookList = _bookService.GetBooks(),
                PersonList = _peopleService.GetPeople(),
            };
            return View(model);
        }

        public IActionResult AddBorrow()
        {
            var model = new BorrowViewModel()
            {
                BorrowList = _borrowService.GetBorrows(),
                BookList = _bookService.GetBooks(),
                PersonList = _peopleService.GetPeople(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddBorrow(int BookId, int PersonId)
        {
            var model = new BorrowViewModel()
            {
                BorrowList = _borrowService.GetBorrows(),
                BookList = _bookService.GetBooks(),
                PersonList = _peopleService.GetPeople(),
            };

            if(ModelState.IsValid)
            {
                _borrowService.AddBorrow(BookId, PersonId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult ChangeReturnState(int Id, bool IsReturned)
        {
            _borrowService.ChangeReturnState(Id, IsReturned);
            return RedirectToAction("Index");
        }

        public IActionResult EditBorrow(int Id, int BookId, int PersonId, DateTime BorrowDate)
        {
            var model = new BorrowViewModel()
            {
                Id = Id,
                BookId = BookId,
                PersonId = PersonId,
                BorrowDate = BorrowDate,
                BorrowList = _borrowService.GetBorrows(),
                BookList = _bookService.GetBooks(),
                PersonList = _peopleService.GetPeople(),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditThisBorrow(int Id, int BookId,  int PersonId, DateTime BorrowDate)
        {
            var model = new BorrowViewModel()
            {
                Id = Id,
                BookId = BookId,
                PersonId = PersonId,
                BorrowDate = BorrowDate,
                BorrowList = _borrowService.GetBorrows(),
                BookList = _bookService.GetBooks(),
                PersonList = _peopleService.GetPeople(),
            };

            if (ModelState.IsValid) { 
                _borrowService.EditBorrow(Id, BookId, PersonId, BorrowDate);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
