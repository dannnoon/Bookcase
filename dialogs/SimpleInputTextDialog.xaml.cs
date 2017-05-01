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

namespace Bookcase.dialogs
{
    /// <summary>
    /// Interaction logic for SimpleInputTextDialog.xaml
    /// </summary>
    public partial class SimpleInputTextDialog : Window
    {
        public SimpleInputTextDialog()
        {
            InitializeComponent();

            var context = DataContext as BaseDialogWindowVM;
            context.CloseDialog += OnCloseDialog;
        }

        private void OnCloseDialog(DialogEventArgs args)
        {
            DialogResult = args.Result;
            Close();
        }
    }
}
