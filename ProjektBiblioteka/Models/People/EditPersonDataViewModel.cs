using ProjektBiblioteka.Models.Books;

namespace ProjektBiblioteka.Models.People
{
    public class EditPersonDataViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<PersonModel> People { get; set; }
    }
}
