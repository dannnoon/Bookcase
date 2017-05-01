using Bookcase.converters;
using Bookcase.db;
using Bookcase.dialogs;
using Bookcase.model;
using Bookcase.ui.uibases;
using Bookcase.util;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
        public ICommand PickCoverImageCommand { get { return new RelayCommand(PickCoverImageCommandAction); } }
        public ICommand DownloadCoverImageCommand { get { return new RelayCommand(DownloadCoverImageCommandAction); } }
        public ICommand DeleteCoverCommand { get { return new RelayCommand(DeleteCoverCommandAction); } }

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

        public void PickCoverImageCommandAction(Object parameter)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            dialog.DefaultExt = ".png";
            dialog.Filter = "Pliki JPEG (*.jpeg)|*.jpeg|Pliki PNG (*.png)|*.png|Pliki JPG (*.jpg)|*.jpg";

            if (dialog.ShowDialog() == true)
            {
                var path = dialog.FileName;
                if (!String.IsNullOrWhiteSpace(path))
                    HandleImageSelection(path);
            }
        }

        private void HandleImageSelection(String path)
        {
            Book.Cover = File.ReadAllBytes(path);
            Book.HasCover = true;
        }

        private void DownloadCoverImageCommandAction(Object parameter)
        {
            var dialog = new SimpleInputTextDialog();
            var context = dialog.DataContext as SimpleInputTextDialogVM;

            context.InitDialog("Adres okładki", "Proszę podać adres, pod którym znajduje się okładka ksiązki.", "Anuluj", "Pobierz", "Adres www");

            if (dialog.ShowDialog() == true)
            {
                var address = context.InputValue;

                if (!String.IsNullOrWhiteSpace(address))
                {
                    var loader = new UrlImageLoader(address);
                    loader.ImageHandlerEvent += OnImageLoaded;
                    loader.Load();
                }
            }
        }

        private void OnImageLoaded(bool success, byte[] image)
        {
            if (success)
            {
                Book.Cover = image;
                Book.HasCover = true;
            }
        }

        private void DeleteCoverCommandAction(Object parameter)
        {
            Book.HasCover = false;
            Book.Cover = null;
        }

    }
}
