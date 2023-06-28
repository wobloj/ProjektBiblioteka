using ProjektBiblioteka.Context;
using ProjektBiblioteka.Models.Books;
using ProjektBiblioteka.Models.Borrow;
using ProjektBiblioteka.Models.People;

namespace ProjektBiblioteka.Services.Borrow
{
    public class BorrowService : IBorrowService
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BorrowService(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public void AddBorrow(int BookId, int PersonId )
        {
            var book = _libraryDbContext.Books.FirstOrDefault( a => a.Id == BookId );
            var person = _libraryDbContext.People.FirstOrDefault( a => a.Id == PersonId );
            if( book != null && person != null)
            {
                _libraryDbContext.Borrow.Add(new BorrowModel
                {
                    BookId = BookId,
                    PersonId = PersonId,
                    BorrowDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(14),
                    IsReturned = false
                });
                _libraryDbContext.SaveChanges();
            }
        }

        public void DeleteBorrow(int Id)
        {
            var borrow = _libraryDbContext.Borrow.FirstOrDefault(x => x.Id == Id);
            if (borrow != null)
            {
                _libraryDbContext.Remove(borrow);
                _libraryDbContext.SaveChanges();
            }
        }

        public void EditBorrow(int Id, int BookId, int PersonId, DateTime BorrowDate)
        {
            var borrow = _libraryDbContext.Borrow.FirstOrDefault(x => x.Id == Id);
            if(borrow != null)
            {
                borrow.BookId = BookId;
                borrow.PersonId = PersonId;
                borrow.BorrowDate = BorrowDate;
                borrow.ReturnDate = BorrowDate.AddDays(14);
            }
        }

        public BorrowModel GetBorrow(int Id)
        {
            var borrow = _libraryDbContext.Borrow.FirstOrDefault(x => x.Id == Id);
            return borrow ?? new BorrowModel();
        }

        public List<BorrowModel> GetBorrows()
        {
            return _libraryDbContext.Borrow.ToList();
        }

        public void ChangeReturnState(int Id, bool IsReturned)
        {
            var borrow = _libraryDbContext.Borrow.FirstOrDefault(x => x.Id == Id);
            if (borrow.IsReturned)
            {
                borrow.IsReturned = !IsReturned;  
            }
            else
            {
                borrow.IsReturned = !IsReturned;
            }
            _libraryDbContext.SaveChanges();
        }
    }
}
