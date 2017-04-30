using Bookcase.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.ui.uibases
{
    class BaseDialogWindowVM
    {
        public delegate void DialogEventHandler(DialogEventArgs args);

        public event DialogEventHandler CloseDialog;

        protected void OnCloseDialog(DialogEventArgs args)
        {
            CloseDialog?.Invoke(args);
        }
    }
}
