using Bookcase.model;
using Bookcase.ui.uibases;
using Bookcase.util;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookcase.dialogs
{
    [ImplementPropertyChanged]
    class SimpleYesNoDialogVM : BaseDialogWindowVM
    {
        public ICommand CancelCommand { get { return new RelayCommand(CancelCommandAction); } }
        public ICommand AcceptCommand { get { return new RelayCommand(AcceptCommandAction); } }

        public String Title { get; set; }
        public String Content { get; set; }
        public String CancelText { get; set; }
        public String AcceptText { get; set; }

        public SimpleYesNoDialogVM()
        {

        }

        public void InitDialog(String title, String content, String cancelText, String acceptText)
        {
            Title = title;
            Content = content;
            CancelText = cancelText;
            AcceptText = acceptText;
        }

        private void CancelCommandAction(Object parameter)
        {
            OnCloseDialog(new DialogEventArgs(false));
        }

        private void AcceptCommandAction(Object parameter)
        {
            OnCloseDialog(new DialogEventArgs(true));
        }

    }
}
