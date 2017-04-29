using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.model
{
    class Book
    {
        public int BookId { get; set; }

        public String Title { get; set; }
        public String Author { get; set; }
        public String CoverUri { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public FilterType Filter { get; set; }

        public bool HasCover { get; set; }

        public Book() { }

        public Book(String title) : this(title, "Nieznany") { }

        public Book(String title, String author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
}
