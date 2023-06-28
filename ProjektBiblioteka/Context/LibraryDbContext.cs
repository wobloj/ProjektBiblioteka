using Microsoft.EntityFrameworkCore;
using ProjektBiblioteka.Models.Books;
using ProjektBiblioteka.Models.Borrow;
using ProjektBiblioteka.Models.People;

namespace ProjektBiblioteka.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
        {

        }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { 
        
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<PersonModel> People { get; set; }
        public DbSet<BorrowModel> Borrow { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

    }
}
