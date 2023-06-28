using ProjektBiblioteka.Models.Books;
using ProjektBiblioteka.Models.People;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjektBiblioteka.Models.Borrow
{
    public class BorrowViewModel
    {
        public BorrowViewModel() { }

        public int Id { get; set; }
        public BookModel Book { get; set; }
        public PersonModel Person { get; set; }
        public DateTime BorrowDate { get; set; }
        public int BookId { get; set; }
        public int PersonId { get; set; }
        public IEnumerable<BorrowModel> BorrowList { get; set; }
        public IEnumerable<BookModel> BookList { get; set; }
        public IEnumerable<PersonModel> PersonList { get; set; }
    }
}
