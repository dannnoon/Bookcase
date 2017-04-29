using Bookcase.db;
using Bookcase.model;
using Bookcase.util;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookcase.ui
{
    [ImplementPropertyChanged]
    class MainWindowVM
    {
        public ICommand AddBookCommand { get { return new RelayCommand(AddBookCommandAction); } }

        public ObservableCollection<String> Sorters { get; set; }
        public ObservableCollection<bool> Filters { get; set; }
        public ObservableCollection<Book> Books { get; set; }

        public MainWindowVM()
        {
            Sorters = new ObservableCollection<string>(DefaultsUtils.GetDefaultSorters());
            Filters = new ObservableCollection<bool>(DefaultsUtils.GetDefaultFilters());
            LoadBooks();

            Filters.CollectionChanged += OnFilterSelectedEvent;
        }

        private void OnFilterSelectedEvent(object sender, EventArgs args)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            FilterType selectedFilter = GetSelectedFilterType();
            if (selectedFilter != FilterType.ALL)
                Books = new ObservableCollection<Book>(BooksDAO.GetBooksByFilter(selectedFilter));
            else
                Books = new ObservableCollection<Book>(BooksDAO.GetAllBooks());
        }

        private FilterType GetSelectedFilterType()
        {
            for (int i = 0; i < Filters.Count; i++)
            {
                if (Filters.ElementAt(i))
                    return (FilterType)i;
            }

            return FilterType.ALL;
        }

        private void AddBookCommandAction()
        {
            AddBookWindow window = new AddBookWindow();
            if (window.ShowDialog() == true)
            {

            }
        }

    }
}
