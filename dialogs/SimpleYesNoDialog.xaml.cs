using Bookcase.model;
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
    /// Interaction logic for SimpleYesNoDialog.xaml
    /// </summary>
    public partial class SimpleYesNoDialog : Window
    {
        public SimpleYesNoDialog()
        {
            InitializeComponent();

            var context = (SimpleYesNoDialogVM)DataContext;
            context.CloseDialog += OnCloseDialog;
        }

        private void OnCloseDialog(DialogEventArgs args)
        {
            DialogResult = args.Result;
            Close();
        }
    }
}
