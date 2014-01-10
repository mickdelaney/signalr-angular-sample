using System;
using System.Net;
using System.Text;
using Hyperletter;
using Hyperletter.Letter;

namespace Services
{
    class Program
    {
        static void Main(string[] args)
        {
            var socket = new HyperSocket();
            socket.Bind(IPAddress.Any, 8001);

            Console.WriteLine("TRANSMITTING");
            for (var i = 0; i < 100; i++)
            {
                var message = string.Format("Message: {0}", i);
                var bytes = Encoding.UTF8.GetBytes(message);
                socket.Send(new Letter(LetterOptions.Ack | LetterOptions.Requeue, bytes));
            }

            Console.ReadLine();
        }
    }
}
