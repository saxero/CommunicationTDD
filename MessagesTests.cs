using System.Collections.Generic;
using NUnit.Framework;

namespace CommunicationTDDTests
{
    [TestFixture]
    public class MessagesTests
    {
        static private object[] _sourceLists = {
            new object[] {
                new List<string>
                {
                    "Primer mensaje",
                    "Segundo mensaje",
                    "Tercer mensaje",
                }
            },  //case 1
            new object[]
            {
                new List<string>
                {
                    "HEL",
                    "DST",
                    "OPL",
                }

            } //case 2
        };

        //static List<string> mensajeList = new List<string>{
        //    "Primer mensaje",
        //    "Segundo mensaje",
        //    "Tercer mensaje",
        //};

        [Test]
        public void SendToApp_MessageIsSent_ReturnsTrue()
        {
            // arrange
            var mensajero = new Mensajero();
            string mensaje = "Un mensaje";

            // act
            var resultado = mensajero.sendToApp(mensaje);

            // assert
            Assert.IsTrue(resultado);
        }


        [Test]
        [TestCase("Un mensaje")]
        [TestCase("Un segundo mensaje")]
        [TestCase("")]
        public void SendToApp_MessageIsSent_MessageIsReceivedByApp(string mensaje)
        {
            // arrange
            var mensajero = new Mensajero();

            // act
            mensajero.sendToApp(mensaje);
            string receivedMessage = mensajero.getLastMessageInApp();

            // assert
            Assert.AreEqual(mensaje, receivedMessage);
        }

        [Test]
        [TestCaseSource("_sourceLists")]
        public void SendToApp_SeveralMessagesAreSent_AllMessagesAreReceivedByApp(List<string> mensajes)
        {
            // arrange
            var mensajero = new Mensajero();
            List<string> receivedMessages = new List<string>();
            
            // act
            foreach (var v in mensajes)
            {
                mensajero.sendToApp(v);
                receivedMessages.Add(mensajero.getLastMessageInApp());
            }

            // assert
            Assert.AreEqual(mensajes, receivedMessages);
        }

        [Test]
        public void SendToApp_SeveralMessagesAreSent_AllMessagesAreReceivedInOrderByApp()
        {
            // arrange
            var mensajero = new Mensajero();

            List<string> mensajes = new List<string>() { 
                "Primer mensaje",
                "Segundo mensaje",
                "Tercer mensaje",
                "Cuarto mensaje"
            };

            // act
            foreach (var v in mensajes)
            {
                mensajero.sendToApp(v);
            }

            // assert
            var receivedMessages = mensajero.receivedMessagesByApp();
            Assert.AreEqual(mensajes, receivedMessages);
        }
    }
}
