using Bookcase.ui.uibases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.dialogs
{
    class SimpleInputTextDialogVM : SimpleYesNoDialogVM
    {
        public String InputValue { get; set; }
        public String Hint { get; set; }

        public void InitDialog(String title, String content, String cancelText, String acceptText, String hint)
        {
            Hint = hint;
            InitDialog(title, content, cancelText, acceptText);
        }
    }
}
