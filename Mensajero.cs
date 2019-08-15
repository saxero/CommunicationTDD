using System.Collections.Generic;
using System.Linq;

namespace CommunicationTDDTests
{
    internal class Mensajero
    {
        private string messageToApp;
        private List<string> mensajesReceivedByApp = new List<string>();


        public Mensajero()
        {
        }

        public bool sendToApp(string mensaje)
        {
            mensajesReceivedByApp.Add(mensaje);
            return true;
        }

        public string getLastMessageInApp()
        {
            return mensajesReceivedByApp.LastOrDefault();
        }

        public List<string>receivedMessagesByApp()
        {
            return mensajesReceivedByApp;
        }
    }
}