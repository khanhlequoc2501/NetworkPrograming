using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    public partial class Server : Form
    {
        bool connect = true;
        private byte[] data = new byte[1024];
        public List<InformPlayer> player;
        string message;
        Thread receive,send;
        int count = 0;
        int songuoi = 4;

        List<string> danhsach;


        private Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        

        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            player = new List<InformPlayer>();
        }


        private void AppceptCallback(IAsyncResult ar)
        {
            Socket socket = socketServer.EndAccept(ar);
            player.Add(new InformPlayer(socket));
            socket.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            socketServer.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private IAsyncResult arreceive;
        private void ReceiveCallback(IAsyncResult ar)
        {
            arreceive = ar;
            receive = new Thread(new ThreadStart(ReceiveData));
            receive.Start();
            Socket socket = (Socket)arreceive.AsyncState;
        }
        void ReceiveData()
        {
            Socket curenSocket = (Socket)arreceive.AsyncState;

            if (curenSocket.Connected)
            {
                int received;
                try
                {
                    received = curenSocket.EndReceive(arreceive);
                }
                catch (Exception)
                {
                    for (int i = 0; i < player.Count; i++)
                    {
                        if (player[i].socketclient.RemoteEndPoint.ToString().Equals(curenSocket.RemoteEndPoint.ToString()))
                        {
                            player.RemoveAt(i);
                        }
                    }
                    return;
                }
                if (received != 0)
                {
                    byte[] mess = new byte[received];
                    Array.Copy(data, mess, received);
                    string text = Encoding.UTF8.GetString(mess);
                    string[] dulieu = text.Split(':');

                    if (dulieu[0] == "exit")
                    {
                        if (dulieu[1] == "#NULL")
                        {
                            for (int i = 0; i < player.Count; i++)
                                if (player[i].socketclient.ToString().Equals(curenSocket.ToString()))
                                {
                                    player.RemoveAt(i);
                                    break;
                                }
                        }
                        else
                        {
                            listBox1.Items.Remove(dulieu[1]);

                            for (int i = 0; i < player.Count; i++)
                                if (player[i].name.ToString().Equals(dulieu[1]))
                                {
                                    player.RemoveAt(i);
                                    resetToEnd();
                                    break;
                                }
                            sendalldata("visible");
                            Thread.Sleep(500);
                            thutuuser();
                            count = listBox1.Items.Count;
                            connect = true;
                        }
                    }
                    else if (dulieu[0] == "user")
                    {
                        Thread.Sleep(500);
                        if (connect == true)
                        {
                            int ktr = 0;
                            string[] ktra = dulieu[1].Split(':');
                            for (int i = 0; i < player.Count; i++)
                            {
                                if (player[i].name.Equals(ktra[0]))
                                    ktr = 1;
                            }
                            if (ktr == 0)
                            {
                                if (count + 1 > songuoi)
                                {
                                    Sendata(curenSocket, "du");
                                }
                                else
                                {
                                    Sendata(curenSocket, "thanhcong");
                                    Thread.Sleep(1000);
                                    for (int i = 0; i < player.Count; i++)
                                    {
                                        if (curenSocket.RemoteEndPoint.ToString().Equals(player[i].socketclient.RemoteEndPoint.ToString()))
                                        {
                                            player[i].name = ktra[0];
                                            listBox1.Items.Add(ktra[0]);
                                            count = listBox1.Items.Count;
                                            thutuuser();
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                                Sendata(curenSocket, "user");
                        }
                        else
                            Sendata(curenSocket, "dangchoi");
                    }
                    else if (dulieu[0] == "nut")
                    {
                        for (int i = 0; i < player.Count; i++)
                        {
                            if (curenSocket.RemoteEndPoint.ToString().Equals(player[i].socketclient.RemoteEndPoint.ToString()))
                            {
                                player[i].nut += Convert.ToInt32(dulieu[1]);
                            }
                        }
                        thutuuser();
                        count--;
                        if (count == 0)
                        {
                            Thread.Sleep(1500);
                            sosanhnut();
                            if (layLuocHienTai(curenSocket) == 0)
                            {
                                thutuuser();
                                connect = true;
                                string wi = sosanhdiem();
                                Thread.Sleep(500);
                                sendalldata("winner:" + wi);
                                resetToEnd();
                                Thread.Sleep(1000);
                                sendalldata("visible");
                            }
                            else
                            {
                                thutuuser();
                                Thread.Sleep(1000);
                                sendalldata("play");
                                count = listBox1.Items.Count;
                            }
                        }
                    }
                    else if (dulieu[0] == "play")
                    {
                        sendalldata("play");
                        connect = false;
                    }
                }
                else
                {
                    for (int i = 0; i < player.Count; i++)
                    {
                        if (player[i].socketclient.RemoteEndPoint.ToString().Equals(curenSocket.RemoteEndPoint.ToString()))
                        {
                            player.RemoveAt(i);
                        }
                    }
                }
            }
            try
            {
                curenSocket.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), curenSocket);
            }
            catch (Exception)
            { }
        }   
        private bool kiemtralist(string s)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
                if (s == listBox1.Items[i].ToString())
                    return true;
            return false;
        }
        private Socket laysocket(string n)
        {
            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].name.Equals(n))
                {
                    return player[i].socketclient;
                }
            }
            return socketServer;
        }
        private int laydiem(string nguoichoix)
        {
            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].name.Equals(nguoichoix))
                {
                    return player[i].diem;
                }
            }
            return 0;
        }
        private int laynut(string nguoichoix)
        {
            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].name.Equals(nguoichoix))
                {
                    return player[i].nut;
                }
            }
            return 0;
        }
        private int layLuocHienTai(Socket gluot)
        {
            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].socketclient.Equals(gluot))
                {
                    return player[i].luot;
                }
            }
            return 0;
        }
        private void sosanhnut()
        {
            int nutcaonhat = player[0].nut;
            for(int i =0; i<player.Count;i++)
            {
                if (player[i].nut > nutcaonhat)
                    nutcaonhat = player[i].nut;
                player[i].luot--;
            }
            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].nut == nutcaonhat)
                    player[i].diem = player[i].diem +1;
                player[i].nut = 0;
            }
        }
        private string sosanhdiem()
        {
            string winner ="";
            int diemcaonhat = player[0].diem;
            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].diem > diemcaonhat)
                    diemcaonhat = player[i].diem;
            }
            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].diem == diemcaonhat)
                    winner = winner + player[i].name+" & ";
            }
            int t = winner.Length;
            return winner.Substring(0,t-3);
        }
        private string laytenuser(Socket s)
        {
            for (int i = 0; i < player.Count; i++)
            {
                if (s.RemoteEndPoint.ToString().Equals(player[i].socketclient.RemoteEndPoint.ToString()))
                {
                    return player[i].name;
                }
            }
            return "";
        }
        private string lstuser;
        private void thutuuser()
        {
            danhsach = new List<string>();
            for(int i=0; i<listBox1.Items.Count;i++)
            {
                int diemx = laydiem(listBox1.Items[i].ToString());
                int nutx = laynut(listBox1.Items[i].ToString());
                string nguoi = listBox1.Items[i].ToString();
                string tt = (i+1).ToString() + "." + nguoi + "/" + diemx.ToString() + "/" + nutx.ToString();
                danhsach.Add(tt);
            }
            int sluser = listBox1.Items.Count;
            lstuser ="list:"+sluser+":";
            for (int i = 0; i < danhsach.Count; i++)
            {
                lstuser +=danhsach[i].ToString();
                if(i != danhsach.Count -1)
                    lstuser+='|';
            }
            sendalldata(lstuser);
        }
        private void resetToEnd()
        {
            count = listBox1.Items.Count;
            for (int i = 0; i < player.Count; i++)
            {
                player[i].nut = 0;
                player[i].diem = 0;
                player[i].luot = 10;
            }
        }
        private void sendalldata(string s)
        {
            for(int i=0; i<listBox1.Items.Count;i++)
            {
                Socket nguoichoi = laysocket(listBox1.Items[i].ToString());
                Sendata(nguoichoi,s);
                Thread.Sleep(30);
            }
        }
        void Sendata(Socket socket, string noidung)
        {
            byte[] data = Encoding.UTF8.GetBytes(noidung);
            try
            {
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            }
            catch (Exception) { }
        }
        private void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }       
        private void server_Load(object sender, EventArgs e)
        {

        }
        private void btStart_Click(object sender, EventArgs e)
        {
            textBox1.Text += ("Đang chờ người chơi kết nối đến");
            socketServer.Bind(new IPEndPoint(IPAddress.Any, 100));
            socketServer.Listen(1);
            socketServer.BeginAccept(new AsyncCallback(AppceptCallback), null);
            btStart.Enabled = false;
        }

        private void Server_Load_1(object sender, EventArgs e)
        {

        }
    }
}
