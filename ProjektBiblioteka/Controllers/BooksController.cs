using Microsoft.AspNetCore.Mvc;
using ProjektBiblioteka.Context;
using ProjektBiblioteka.Models.Books;
using ProjektBiblioteka.Services.Books;
using SQLitePCL;

namespace ProjektBiblioteka.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksService _booksService;

        public BooksController(ILogger<BooksController> logger, IBooksService booksService)
        {
            _logger = logger;
            _booksService = booksService;
        }

        public IActionResult Index()
        {
            var model = new BooksViewModel()
            {
                Books = _booksService.GetBooks()
            };
            return View(model);
        }
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(string Title, string Description, string Category, int Pages, string Author, int Year)
        {
            if(ModelState.IsValid)
            {
                _booksService.NewBook(Title, Description, Pages, Category, Author, Year);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult RemoveBook(int Id)
        {
            _booksService.DeleteBook(Id);
            return RedirectToAction("Index");
        }

        public IActionResult EditBook(string Title, string Description, string Category, int Pages, string Author, int Year)
        {
            var model = new EditBookViewModel()
            {
                Title = Title,
                Description = Description,
                Category = Category,
                Pages = Pages,
                Author = Author,
                Year = Year
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditThisBook(int Id, string Title, string Description, string Category, int Pages, string Author, int Year) { 
            if(ModelState.IsValid)
            {
                _booksService.UpdateBook(Id, Title, Description, Pages, Category, Author, Year);
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
