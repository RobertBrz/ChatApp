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
        Socket client;

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
                tcpClient.Client.Connect("192.168.1.111", 22022);
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

                    break;
            }
        }
    }
}
