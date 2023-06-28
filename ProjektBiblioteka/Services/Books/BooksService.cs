using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjektBiblioteka.Context;
using ProjektBiblioteka.Models.Books;

namespace ProjektBiblioteka.Services.Books
{
    public class BooksService : IBooksService
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BooksService(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public void DeleteBook(int Id)
        {
            var book = _libraryDbContext.Books.FirstOrDefault(x => x.Id == Id);
            if (book != null)
            {
                _libraryDbContext.Books.Remove(book);
                _libraryDbContext.SaveChanges();
            }
        }

        public BookModel GetBook(int Id)
        {
            var book = _libraryDbContext.Books.FirstOrDefault();
            return book ?? new BookModel();
        }

        public List<BookModel> GetBooks()
        {
            return _libraryDbContext.Books.ToList();
        }

        public void NewBook(string Title, string Description, int Pages, string Category, string Author, int Year)
        {
            _libraryDbContext.Add(new BookModel
            {
                Title = Title,
                Description = Description,
                Pages = Pages,
                Category = Category,
                Author = Author,
                Year = Year
            });
            _libraryDbContext.SaveChanges();
        }

        public void UpdateBook(int Id, string Title, string Description, int Pages, string Category, string Author, int Year)
        {
            var book = _libraryDbContext.Books.FirstOrDefault(x => x.Id == Id);
            if (book != null)
            {
                book.Title = Title;
                book.Description = Description;
                book.Author = Author;
                book.Pages = Pages;
                book.Category = Category;
                book.Year = Year;
            }
            _libraryDbContext.SaveChanges();
        }

        public Task<List<SelectListItem>> populateSelectList()
        {
            return Task.Factory.StartNew(() =>
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem(){Value = "Komedia", Text="Komedia"},
                    new SelectListItem(){Value = "Dramat", Text = "Dramat"},
                    new SelectListItem(){Value = "Horror", Text = "Horror" },
                    new SelectListItem(){Value = "Akcja", Text = "Akcja"},
                    new SelectListItem(){Value = "Sci-Fi", Text = "Sci-Fi"},
                    new SelectListItem(){Value = "Bajka", Text = "Bajka"}
                };
            });
        }
    }
}
