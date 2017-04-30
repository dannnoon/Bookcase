using Bookcase.converters;
using Bookcase.db;
using Bookcase.model;
using Bookcase.ui.uibases;
using Bookcase.util;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookcase.ui
{
    [ImplementPropertyChanged]
    class AddBookWindowVM : BaseDialogWindowVM
    {
        public ICommand SaveBookCommand { get { return new RelayCommand(SaveBookCommandAction); } }
        public ICommand AddGenreCommand { get { return new RelayCommand(AddGenreCommandAction); } }

        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<String> Filters { get; set; }
        public Book Book { get; set; }

        public AddBookWindowVM()
        {
            LoadGenres();
            InitFilters();

            Book = new Book() { Filter = FilterType.NOT_OWNED };
        }

        private void LoadGenres()
        {
            Genres = new ObservableCollection<Genre>(GenreDAO.GetAllGenres());
        }

        private void InitFilters()
        {
            Filters = new ObservableCollection<String>(new String[] {
                Properties.Resources.FilterTypeRead,
                Properties.Resources.FilterTypeStarted,
                Properties.Resources.FilterTypeNotRead,
                Properties.Resources.FilterTypeNotOwned
            });
        }

        private void SaveBookCommandAction(Object parameter)
        {
            BooksDAO.AddBook(Book);
            OnCloseDialog(new DialogEventArgs(true));
        }

        private void AddGenreCommandAction(Object parameter)
        {
            var window = new AddGenreWindow();
            if (window.ShowDialog() == true)
            {
                LoadGenres();
            }
        }
    }
}
