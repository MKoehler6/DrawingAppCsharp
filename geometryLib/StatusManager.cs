using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometryLib
{
    public class StatusManager
    {
        private static StatusManager statusManager = null;

        public static StatusManager Instance
        {
            get
            {
                if (statusManager == null)
                {
                    statusManager = new StatusManager();
                }
                return statusManager;
            }
        }

        public event EventHandler<StatusMessageEventArgs> StatusMessageChange;

        private StatusManager() { }

        public void SetStatus(string statusMessage)
        {
            StatusMessageChange(this, new StatusMessageEventArgs(statusMessage));
        }
    }
}
