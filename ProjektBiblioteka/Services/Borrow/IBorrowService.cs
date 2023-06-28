using ProjektBiblioteka.Models.Books;
using ProjektBiblioteka.Models.Borrow;
using ProjektBiblioteka.Models.People;

namespace ProjektBiblioteka.Services.Borrow
{
    public interface IBorrowService
    {
        public List<BorrowModel> GetBorrows();
        public BorrowModel GetBorrow(int Id);
        public void AddBorrow(int BookId, int PersonId);
        public void EditBorrow(int Id, int BookId, int PersonId, DateTime BorrowDate);
        public void DeleteBorrow(int Id);
        public void ChangeReturnState(int Id, bool IsReturned);
    }
}
