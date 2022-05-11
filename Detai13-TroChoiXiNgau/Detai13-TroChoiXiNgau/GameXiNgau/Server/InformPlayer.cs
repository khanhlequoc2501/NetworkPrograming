using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class InformPlayer
    {
        public string name { get; set; }
        public Socket socketclient { get; set; }
        public int diem { get; set; }
        public int nut { get; set; }
        public int luot { get; set; }
        public InformPlayer(Socket s)
        {
            this.socketclient = s;
            this.name = " ";
            this.diem = 0;
            this.nut = 0;
            this.luot = 10;
        }
    }
}
