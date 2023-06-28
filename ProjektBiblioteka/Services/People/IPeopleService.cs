using ProjektBiblioteka.Context;
using ProjektBiblioteka.Models.People;

namespace ProjektBiblioteka.Services.People
{
    public interface IPeopleService
    {
        public void DeletePerson(int Id);
        public PersonModel GetPerson(int Id);
        public List<PersonModel> GetPeople();
        public void AddPerson(string FirstName, string LastName, string Email, string Phone);
        public void UpdatePersonData(int Id, string FirstName, string LastName, string Email, string Phone);
    }
}
