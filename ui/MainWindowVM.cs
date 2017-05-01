using Bookcase.db;
using Bookcase.dialogs;
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
        public ICommand EditBookCommand { get { return new RelayCommand(EditBookCommandAction); } }
        public ICommand DeleteBookCommand { get { return new RelayCommand(DeleteBookCommandAction); } }
        public ICommand NoteCommand { get { return new RelayCommand(NoteCommandAction); } }

        public ObservableCollection<String> Sorters { get; set; }
        public ObservableCollection<bool> Filters { get; set; }
        public ObservableCollection<Book> Books { get; set; }

        private String SortFilter_;
        public String SortFilter
        {
            get { return SortFilter_; }

            set
            {
                SortFilter_ = value;
                LoadBooks();
            }
        }

        private String SearchText_;
        public String SearchText
        {
            get { return SearchText_; }

            set
            {
                SearchText_ = value;
                LoadBooks();
            }
        }

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

        private void AddBookCommandAction(Object paramter)
        {
            var window = new AddBookWindow();
            if (window.ShowDialog() == true)
            {
                var data = (AddBookWindowVM)window.DataContext;
                var filter = GetSelectedFilterType();

                if (data.Book.Filter == filter || (filter == FilterType.ALL && filter != FilterType.NOT_OWNED))
                {
                    LoadBooks();
                }
            }
        }

        private void EditBookCommandAction(Object parameter)
        {
            Book book = parameter as Book;

            var window = new AddBookWindow();

            var data = (AddBookWindowVM)window.DataContext;
            data.Book = new Book(book);

            if (window.ShowDialog() == true)
            {
                Books.Remove(book);

                var updatedBooks = BooksDAO.GetBookById(book.BookId);
                var filter = GetSelectedFilterType();

                if (updatedBooks.Filter == filter || (filter == FilterType.ALL && filter != FilterType.NOT_OWNED))
                {
                    Books.Add(updatedBooks);
                    RefreshBooks();
                }
            }
        }

        private void DeleteBookCommandAction(Object parameter)
        {
            var book = (Book)parameter;
            var dialog = new SimpleYesNoDialog();
            var data = (SimpleYesNoDialogVM)dialog.DataContext;

            data.InitDialog("Usuwanie", String.Format("Jesteś pewien, że chcesz usunąć: {0}?", book.Title), "Nie", "Tak");

            if (dialog.ShowDialog() == true)
            {
                Books.Remove(book);
                BooksDAO.DeleteBook(book.BookId);
            }
        }

        private void NoteCommandAction(Object parameter)
        {
            var book = parameter as Book;
            var dialog = new SimpleInputTextDialog();
            var context = dialog.DataContext as SimpleInputTextDialogVM;

            context.InitDialog("Notatka", "Poniżej możesz wpisać treść notatki.", "Anuluj", "Zapisz", "Wpisz treść...");
            context.InputValue = book.Note;

            if (dialog.ShowDialog() == true)
            {
                var copy = new Book(book);
                copy.Note = context.InputValue;

                BooksDAO.AddBook(copy);

                book.Note = context.InputValue;
            }
        }

        private void LoadBooks()
        {
            List<Book> books;
            FilterType selectedFilter = GetSelectedFilterType();

            if (selectedFilter != FilterType.ALL)
                books = new List<Book>(BooksDAO.GetBooksByFilter(selectedFilter));
            else
                books = new List<Book>(BooksDAO.GetOwnedBooks());

            SearchForBooks(books);
            SortBooks(books);

            Books = new ObservableCollection<Book>(books);
        }

        private void RefreshBooks()
        {
            List<Book> books = Books.ToList();

            SearchForBooks(books);
            SortBooks(books);

            Books = new ObservableCollection<Book>(books);
        }

        private void SearchForBooks(List<Book> books)
        {
            if (books.Count > 0 && !String.IsNullOrWhiteSpace(SearchText_))
            {
                Dictionary<String, List<Book>> searchActions = new Dictionary<String, List<Book>>()
                {
                    { Properties.Resources.AuthorText, books.Where((x) => x.Author.ToLower().Contains(SearchText_.ToLower())).ToList() },
                    { Properties.Resources.TitleText, books.Where((x) => x.Title.ToLower().Contains(SearchText_.ToLower())).ToList() },
                    { Properties.Resources.GenreText, books.Where((x) => x.Genre.Name.ToLower().Contains(SearchText_.ToLower())).ToList() }
                };

                List<Book> searched;

                if (searchActions.TryGetValue(SortFilter_, out searched))
                {
                    books.Clear();
                    books.InsertRange(0, searched);
                }
            }
        }

        private void SortBooks(List<Book> books)
        {
            if (books.Count > 0 && !String.IsNullOrEmpty(SortFilter_))
            {
                Dictionary<String, List<Book>> sortActions = new Dictionary<String, List<Book>>()
                {
                    { Properties.Resources.AuthorText, books.OrderBy((x) => x.Author).ToList() },
                    { Properties.Resources.TitleText, books.OrderBy((x) => x.Title).ToList() },
                    { Properties.Resources.GenreText, books.OrderBy((x) => x.Genre.Name).ToList() }
                };

                List<Book> sorted;

                if (sortActions.TryGetValue(SortFilter_, out sorted))
                {
                    books.Clear();
                    books.InsertRange(0, sorted);
                }
            }
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

    }
}
