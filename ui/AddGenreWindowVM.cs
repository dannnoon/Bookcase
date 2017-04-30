using Bookcase.db;
using Bookcase.model;
using Bookcase.ui.uibases;
using Bookcase.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookcase.ui
{
    class AddGenreWindowVM : BaseDialogWindowVM
    {
        public ICommand SaveGenreCommand { get { return new RelayCommand(SaveGenreCommandAction); } }

        public Genre Genre { get; set; }

        public AddGenreWindowVM()
        {
            Genre = new Genre();
        }

        private void SaveGenreCommandAction(Object paramter)
        {
            if (!String.IsNullOrEmpty(Genre.Name))
            {
                GenreDAO.AddGenre(Genre);
                OnCloseDialog(new DialogEventArgs(true));
            }
            else
            {
                OnCloseDialog(new DialogEventArgs(false));
            }
        }
    }
}
