using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.model
{
    public class DialogEventArgs : EventArgs
    {
        public bool Result { get; private set; }

        public DialogEventArgs(bool result)
        {
            Result = result;
        }
    }
}
