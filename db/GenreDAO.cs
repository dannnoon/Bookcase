using Bookcase.db;
using Bookcase.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.db
{
    class GenreDAO
    {
        public static void AddGenre(Genre genre)
        {
            using (var db = new BookcaseDB())
            {
                db.Genres.Add(genre);
                db.SaveChanges();
            }
        }

        public static Genre[] GetAllGenres()
        {
            using (var db = new BookcaseDB())
            {
                var genres = from b in db.Genres select b;
                return genres.ToArray();
            }
        }

        public static Genre GetGenreById(int id)
        {
            using (var db = new BookcaseDB())
            {
                return (from b in db.Genres where b.GenreId == id select b).First();
            }
        }
    }
}
