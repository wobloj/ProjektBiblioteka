using ProjektBiblioteka.Models.Books;
using ProjektBiblioteka.Models.People;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektBiblioteka.Models.Borrow
{
    public class BorrowModel
    {
        private BookModel book;
        private PersonModel person;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Wymagane jest ID książki")]
        public int BookId { get; set; }
        public BookModel Book { get => book; set => book = value; }
        [Required(ErrorMessage = "Wymagane jest ID użytkownika")]
        public int PersonId { get; set; }
        public PersonModel Person { get => person; set => person = value; }
        [Required(ErrorMessage = "Wymagana jest data rozpoczęcia wypożyczenia")]
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        
    }
}
