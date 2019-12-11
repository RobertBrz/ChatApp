using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAppServer
{
    class Listener
    {
        static Listener instance;
        public static string serveraddress;
        public static int serverport;
        private readonly ManualResetEvent mre = new ManualResetEvent(false);
        private readonly IDictionary<int, IClientObject> clients = new Dictionary<int, IClientObject>();
        public IDictionary<int, IClientObject> Clients => clients;

        public static Listener Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Listener();
                }
                return instance;
            }
        }

        public void StartListening()
        {
            string hostName = Dns.GetHostName();
            serveraddress = Dns.GetHostByName(hostName).AddressList[0].ToString();
            serverport = 22022;

            var endpoint = new IPEndPoint(IPAddress.Parse(serveraddress), serverport);

            try
            {
                using (var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    listener.Bind(endpoint);
                    listener.Listen(250);
                    while (true)
                    {
                        this.mre.Reset();
                        listener.BeginAccept(this.OnClientConnect, listener);
                        this.mre.WaitOne();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void OnClientConnect(IAsyncResult result)
        {
            this.mre.Set();
            try
            {
                ClientObject client = null;

                lock (this.Clients)
                {
                    var id = !this.Clients.Any() ? 1 : this.Clients.Keys.Max() + 1;

                    Socket clientSocket = (Socket)result.AsyncState;
                    client = new ClientObject((clientSocket).EndAccept(result), id);
                    this.Clients.Add(id, client);
                }

                client.listener.BeginReceive(client.buffer, 0, client.bufferSize, SocketFlags.None, this.ReceiveCallback, client);
            }
            catch (Exception ex)
            {

            }
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            ClientObject client = null;

            try
            {
                client = (ClientObject)result.AsyncState;
                var receive = client.listener.EndReceive(result);
                var ipandport = client.listener.RemoteEndPoint;

                if(receive > 0)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
