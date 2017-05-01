using Bookcase.db;
using Bookcase.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.db
{
    class BooksDAO
    {
        public static void AddBook(Book book)
        {
            using (var db = new BookcaseDB())
            {
                var entity = db.Books.Find(book.BookId);

                if (entity == null)
                {
                    db.Books.Add(book);
                }
                else
                {
                    book.Genre = null;
                    db.Entry(entity).CurrentValues.SetValues(book);
                }

                db.SaveChanges();
            }
        }

        public static Book GetBookById(int id)
        {
            using (var db = new BookcaseDB())
            {
                var book = (from b in db.Books where b.BookId == id select b).First();
                book.Genre = GetGenreById(book.GenreId, db);

                return book;
            }
        }

        public static Book[] GetBooksByFilter(FilterType filter)
        {
            using (var db = new BookcaseDB())
            {
                var books = from b in db.Books where b.Filter == filter select b;

                foreach (Book book in books)
                {
                    book.Genre = GetGenreById(book.GenreId, db);
                }

                return books.ToArray();
            }
        }

        public static Book[] GetAllBooks()
        {
            using (var db = new BookcaseDB())
            {
                var books = from b in db.Books select b;

                foreach (Book book in books)
                {
                    book.Genre = GetGenreById(book.GenreId, db);
                }

                return books.ToArray();
            }
        }

        public static Book[] GetOwnedBooks()
        {
            using (var db = new BookcaseDB())
            {
                var books = from b in db.Books where b.Filter != FilterType.NOT_OWNED select b;

                foreach (Book book in books)
                {
                    book.Genre = GetGenreById(book.GenreId, db);
                }

                return books.ToArray();
            }
        }

        public static void DeleteBook(int bookId)
        {
            using (var db = new BookcaseDB())
            {
                db.Entry(new Book() { BookId = bookId }).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        private static Genre GetGenreById(int id, BookcaseDB db)
        {
            return (from g in db.Genres where g.GenreId == id select g).First();
        }
    }
}
