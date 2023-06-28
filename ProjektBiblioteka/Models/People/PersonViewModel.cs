using ProjektBiblioteka.Models.Books;

namespace ProjektBiblioteka.Models.People
{
    public class PersonViewModel
    {
        public PersonViewModel() { }

        public IEnumerable<PersonModel> People { get; set; }
    }
}
