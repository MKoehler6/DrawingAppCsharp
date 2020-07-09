using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometryLib
{
    /*
     * diese Klasse stellt eine Singleton-Instanz zur Verfügung, mit der Statusmeldungen in der Statuszeile
     * angezeigt werden
     */
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

        // ein delegate, dem in der Klasse MainFrame eine Methode zum Setzen des Textes in der 
        // Statuszeile zugewiesen wird
        // wird dann in der Methode SetStatus aufgerufen
        public event EventHandler<StatusMessageEventArgs> StatusMessageChange;

        private StatusManager() { }

        // ruft das delegate auf und übergibt die Message
        public void SetStatus(string statusMessage)
        {
            StatusMessageChange(this, new StatusMessageEventArgs(statusMessage));
        }
    }
}
