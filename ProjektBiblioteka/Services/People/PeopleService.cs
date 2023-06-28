using ProjektBiblioteka.Context;
using ProjektBiblioteka.Models.Books;
using ProjektBiblioteka.Models.People;

namespace ProjektBiblioteka.Services.People
{
    public class PeopleService : IPeopleService
    {
        private readonly LibraryDbContext _libraryDbContext;

        public PeopleService(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public void DeletePerson(int Id)
        {
            var person = _libraryDbContext.People.FirstOrDefault(x => x.Id == Id);
            if (person != null)
            {
                _libraryDbContext.People.Remove(person);
                _libraryDbContext.SaveChanges();
            }
        }

        public PersonModel GetPerson(int Id)
        {
            var person = _libraryDbContext.People.FirstOrDefault(x => x.Id == Id);
            return person ?? new PersonModel();
        }

        public List<PersonModel> GetPeople()
        {
            return _libraryDbContext.People.ToList();
        }

        public void AddPerson(string FirstName, string LastName, string Email, string Phone)
        {
            _libraryDbContext.Add(new PersonModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone
            });
            _libraryDbContext.SaveChanges();
        }

        public void UpdatePersonData(int Id, string FirstName, string LastName, string Email, string Phone)
        {
            var person = _libraryDbContext.People.FirstOrDefault(x => x.Id == Id);
            if (person != null)
            {
                person.FirstName = FirstName;
                person.LastName = LastName;
                person.Email = Email;
                person.Phone = Phone;
            }
            _libraryDbContext.SaveChanges();
        }
    }
}
