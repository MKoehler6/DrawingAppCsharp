using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometryLib
{
    /*
     * diese Klasse speichert die Status-Message und wird dann dem delegate StatusMessageChange
     * übergeben
     */
    public class StatusMessageEventArgs : EventArgs
    {
        public string Message;

        public StatusMessageEventArgs (string Message)
        {
            this.Message = Message;
        }
    }
}
