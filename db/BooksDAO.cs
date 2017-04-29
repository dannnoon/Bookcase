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
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public static Book GetBookById(int id)
        {
            using (var db = new BookcaseDB())
            {
                return (from b in db.Books where b.BookId == id select b).First();
            }
        }

        public static Book[] GetBooksByFilter(FilterType filter)
        {
            using (var db = new BookcaseDB())
            {
                var books = from b in db.Books where b.Filter == filter select b;
                return books.ToArray();
            }
        }

        public static Book[] GetAllBooks()
        {
            using (var db = new BookcaseDB())
            {
                var books = from b in db.Books select b;
                return books.ToArray();
            }
        }
    }
}
