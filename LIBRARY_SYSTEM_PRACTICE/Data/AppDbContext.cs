using LIBRARY_SYSTEM_PRACTICE.Models;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY_SYSTEM_PRACTICE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<User> users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategoryName)
                .IsUnique();


            modelBuilder.Entity<Book>()
               .HasIndex(c => c.ISBN)
               .IsUnique();


            modelBuilder.Entity<Book>()
               .Property(c => c.IsAvailable)
               .HasDefaultValue(true);


            modelBuilder.Entity<Member>()
               .HasIndex(c => c.MemberEmail)
               .IsUnique();



            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Member>()
                .HasMany(c => c.Borrowings)
                .WithOne(b => b.Member)
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
                .HasMany(c => c.Borrowings)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { CategoryId = 1, CategoryName = "Programming", CategoryDescription = "Programming and software development books"  },
                    new Category { CategoryId = 2, CategoryName = "Database", CategoryDescription = "Database and data management books" }
                );


            modelBuilder.Entity<Book>()
                .HasData(
                    new Book { BookId = 1, Title = "C# Programming", Author = "John Doe", ISBN = "978-1234567890", BookPrice = 29.99m, CategoryId = 1  , IsAvailable = true },
                    new Book { BookId = 2, Title = "C++ Basics", Author = "John Smith", ISBN = "ISBN001", BookPrice = 450, CategoryId = 2, IsAvailable = false }

                );


            modelBuilder.Entity<Member>()
                .HasData(
                    new Member { MemberId = 1 , MemberFullName = "Ahmed Hassan" , MemberEmail = "ahmedhass@gmail.com", MemberPhone = "01012345678" },
                    new Member { MemberId = 2 , MemberFullName = "Sara Mohamed", MemberEmail = "sara@example.com", MemberPhone = "01198765432" }
                );

            modelBuilder.Entity<Borrowing>()
                .HasData(
                    new Borrowing { BorrowingId = 1, BorrowDate = DateTime.Now.AddDays(-7), ReturnDate = null, BookId = 1, MemberId = 1 },
                    new Borrowing { BorrowingId = 2, BorrowDate = DateTime.Now.AddDays(-5), ReturnDate = new DateTime(2026, 09, 25), BookId = 2, MemberId = 2 }
                );



            base.OnModelCreating(modelBuilder);
        }
    }
}
