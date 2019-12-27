using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppClient
{
    class Connection
    {
        TcpClient tcpClient;
        bool connected;
        public Socket client;

        public bool Connected
        {
            get => connected;
            set
            {
                connected = value;
                ConnectionChanged();
            }
        }

        public Connection()
        {
            this.tcpClient = new TcpClient();
            this.client = tcpClient.Client;
        }

        public void Connect()
        {
            try
            {
                tcpClient.Client.Connect("192.168.137.1", 22022);
                byte[] bytestoSend = Encoding.ASCII.GetBytes("CONNECT");
                tcpClient.Client.Send(bytestoSend, bytestoSend.Length, System.Net.Sockets.SocketFlags.None);
                Connected = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void ConnectionChanged()
        {
            switch (connected)
            {
                case true:

                    break;
                case false:
                    client.Close();
                    break;
            }
        }
    }
}
