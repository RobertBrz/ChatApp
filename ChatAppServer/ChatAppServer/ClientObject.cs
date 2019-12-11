using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer
{
    class ClientObject : IClientObject
    {

        public Socket listener;
        private readonly int id;
        public int bufferSize;
        public byte[] buffer;



        public ClientObject(Socket listener, int id = -1)
        {
            this.listener = listener;
            this.id = id;

        }
    }
}
