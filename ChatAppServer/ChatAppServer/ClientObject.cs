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
        private const int Buffer_Size = 2048;
        private Socket listener;
        private readonly int id;
        private byte[] buffer = new byte[Buffer_Size];
        private byte[] messageBuffer;

        public ClientObject(Socket listener, int id = -1)
        {
            this.listener = listener;
            this.id = id;
            this.MessageBuffer = new byte[2048];
        }


        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public bool Close { get; set; }

        public int BufferSize
        {
            get
            {
                return Buffer_Size;
            }
        }

        public byte[] Buffer
        {
            get
            {
                return this.buffer;
            }

        }

        public Socket Listener
        {
            get
            {
                return this.listener;
            }
        }


        public byte[] MessageBuffer { get => messageBuffer; set => messageBuffer = value; }


    }
}
