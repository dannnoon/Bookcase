using Bookcase.model;
using Bookcase.ui.uibases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bookcase.ui
{
    /// <summary>
    /// Interaction logic for AddGenreWindow.xaml
    /// </summary>
    public partial class AddGenreWindow : Window
    {
        public AddGenreWindow()
        {
            InitializeComponent();

            try
            {
                var context = (BaseDialogWindowVM)DataContext;
                context.CloseDialog += OnCloseDialog;
            }
            catch { }
        }

        private void OnCloseDialog(DialogEventArgs args)
        {
            DialogResult = args.Result;
            Close();
        }
    }
}
