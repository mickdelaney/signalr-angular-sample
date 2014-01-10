using System;
using System.Net;
using System.Text;
using Hyperletter;
using Hyperletter.Letter;
using Microsoft.AspNet.SignalR;

namespace SignalR_Sample
{
    public class MessageConsumer
    {
        HyperSocket _socket;

        public void Start()
        {
            _socket = new HyperSocket();

            Console.WriteLine("RECEIVING");
            _socket.Received += socket_Received;
            _socket.Connect(IPAddress.Parse("127.0.0.1"), 8001);
        }

        void socket_Received(ILetter letter, Hyperletter.EventArgs.Letter.IReceivedEventArgs receivedEventArgs)
        {
            Console.WriteLine("RECEIVED");
            const LetterOptions noReliabilityOptions = LetterOptions.SilentDiscard;
            _socket.Send(new Letter(noReliabilityOptions, new[] { (byte)'B' }));

            var hub = GlobalHost.ConnectionManager.GetHubContext<BusHub>();
            var message = Encoding.UTF8.GetString(letter.Parts[0]);
            hub.Clients.All.publish("messageSent", message);
        }
    }
}