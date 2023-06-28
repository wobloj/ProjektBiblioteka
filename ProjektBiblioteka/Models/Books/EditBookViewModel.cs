using System.ComponentModel.DataAnnotations;

namespace ProjektBiblioteka.Models.Books
{
    public class EditBookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? Category { get; set; }

        public string? Author { get; set; }

        public int Pages { get; set; }

        public int Year { get; set; }
        public List<BookModel> Books { get; set; }
    }
}
