using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometryLib
{
    public class StatusMessageEventArgs : EventArgs
    {
        public string Message;

        public StatusMessageEventArgs (string Message)
        {
            this.Message = Message;
        }
    }
}
