using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.model
{
    [ImplementPropertyChanged]
    class Book
    {
        public int BookId { get; set; }

        public String Title { get; set; }
        public String Author { get; set; }
        public String Note { get; set; }

        public int PublicationDate { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public FilterType Filter { get; set; }

        public bool HasCover { get; set; }
        public byte[] Cover { get; set; }

        public Book() { }

        public Book(String title) : this(title, "Nieznany") { }

        public Book(String title, String author)
        {
            this.Title = title;
            this.Author = author;
        }

        public Book(Book book)
        {
            this.BookId = book.BookId;
            this.Title = book.Title;
            this.Author = book.Author;
            this.PublicationDate = book.PublicationDate;
            this.GenreId = book.GenreId;
            this.Filter = book.Filter;
            this.HasCover = book.HasCover;
            this.Cover = book.Cover;
            this.Note = book.Note;
        }
    }
}
