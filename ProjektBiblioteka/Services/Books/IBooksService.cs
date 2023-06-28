using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektBiblioteka.Models.Books;

namespace ProjektBiblioteka.Services.Books
{
    public interface IBooksService
    {
        public List<BookModel> GetBooks();
        public BookModel GetBook(int Id);
        public void NewBook(string Title, string Description, int Pages, string Category, string Author, int Year);
        public void DeleteBook(int Id);
        public void UpdateBook(int Id, string Title, string Description, int Pages, string Category, string Author, int Year);
        Task<List<SelectListItem>> populateSelectList();
    }
}
