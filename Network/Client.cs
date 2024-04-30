using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace AharHighLevel.Network
{
    public class Client
    {
        public Socket _socket { get; set; }
        public ReceivePacket Receive { get; set; }
        public int Id { get; set; }
        private IUnityContainer Container { get; set; }

        public Client(Socket socket, int id, IUnityContainer container)
        {
            Receive = new ReceivePacket(socket, System.Net.IPAddress.Parse(""), 0);
            Receive.StartReceiving();
            this.Container = container;
            _socket = socket;
            Id = id;
        }
    }

    public static class ClientController
    {
        public static List<Client> Clients = new List<Client>();

        public static void AddClient(Socket socket, IUnityContainer container)
        {
            Clients.Add(new Client(socket, Clients.Count, container));
        }

        public static void RemoveClient(int id)
        {
            Clients.RemoveAt(Clients.FindIndex(x => x.Id == id));
        }
    }
}
