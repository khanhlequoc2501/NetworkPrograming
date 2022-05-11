using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientPlayer
{
    public partial class PlayGame : Form
    {
        int nguoi = 4;
        bool start = true;
        Random rd = new Random();
        private byte[] data = new byte[1024];
        Thread randxingau;
        Thread receive;
        public string username;
        Thread thoigian;
        public Thread th;
        int tongdiem, xingau1, xingau2;
        int luot = 10;

        public PlayGame()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private int xingau(int d, PictureBox p)
        {
            int kq = 0;
            if (d == 1) { p.Image = ClientPlayer.Properties.Resources.dice1; kq = 1; }
            if (d == 2) { p.Image = ClientPlayer.Properties.Resources.dice2; kq = 2; }
            if (d == 3) { p.Image = ClientPlayer.Properties.Resources.dice3; kq = 3; }
            if (d == 4) { p.Image = ClientPlayer.Properties.Resources.dice4; kq = 4; }
            if (d == 5) { p.Image = ClientPlayer.Properties.Resources.dice5; kq = 5; }
            if (d == 6) { p.Image = ClientPlayer.Properties.Resources.dice6; kq = 6; }
            return kq;
        }
        private void randomXiNgau()
        {

            for (int i = 0; i < 10; i++)
            {
                xingau1 = rd.Next(1, 7);
                xingau2 = rd.Next(1, 7);
                xingau(xingau1, pictureBox1);
                xingau(xingau2, pictureBox2);
                Thread.Sleep(100);
            }
            tongdiem = xingau1 + xingau2;
            SendData("nut:" + tongdiem.ToString());
            btLac.Enabled = false;
            luot--;
            tbLuot.Text = luot.ToString();
            tbTongNut.Text = tongdiem.ToString();
            thoigian.Abort();
        }
        private void PlayGame_Load(object sender, EventArgs e)
        {
            receive = new Thread(new ThreadStart(ReceiveDataFromServer));
            receive.Start();
            tbUser.Text = username;
            btLac.Enabled = false;
            pictureBox1.Image = ClientPlayer.Properties.Resources.xingau;
            pictureBox2.Image = ClientPlayer.Properties.Resources.xingau;
            tbLuot.Text = luot.ToString();
            thoigian = new Thread(new ThreadStart(demThoiGian));
        }
        int recv;
        public Socket socketClient;
        void ReceiveDataFromServer()
        {
            string message;
            recv = socketClient.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, recv);
            xuli(message);
        }

        void xuli(string message)
        {
            string[] mess = message.Split(':');
            switch (mess[0])
            {
                case "play":
                    start = false;
                    btBatDau.Visible = false;
                    btLac.Enabled = true;
                    thoigian = new Thread(new ThreadStart(demThoiGian));
                    thoigian.Start();
                    break;
                case "visible":
                    resetGame();
                    break;
                case "list":
                    tbNguoiChoi.Clear();
                    tbDiem.Clear();
                    tbNut.Clear();

                    lbnguoi.Text = mess[1];
                    string[] inf = mess[2].Split('|');
                    for (int i = 0; i < inf.Length; i++)
                    {
                        string[] detail = inf[i].Split('/');
                        if (i == 0)
                        {
                            string[] ms = detail[0].Split('.');

                        }
                        tbNguoiChoi.Text += detail[0] + "\r\n";
                        tbDiem.Text += detail[1] + "\r\n";
                        tbNut.Text += detail[2] + "\r\n";
                    }
                    if (Convert.ToInt32(lbnguoi.Text) < nguoi || start == false)
                        btBatDau.Visible = false;
                    else
                        btBatDau.Visible = true;
                    if (Convert.ToInt32(lbnguoi.Text) == 0)
                        resetGame();
                    break;
                case "winner":
                    MessageBox.Show("Người chiến thắn là: " + mess[1], "NGƯỜI CHIẾN THẮNG");
                    resetGame();
                    break;
                default: break;
            }
            ReceiveDataFromServer();
        }
        private void resetGame()
        {
            thoigian.Abort();
            start = true;
            btLac.Enabled = false;
            tbTongNut.Text = "";
            lbThoiGian.Text = "";
            luot = 10;
            tbLuot.Text = "10";
            pictureBox1.Image = ClientPlayer.Properties.Resources.xingau;
            pictureBox2.Image = ClientPlayer.Properties.Resources.xingau;
            if (Convert.ToInt32(lbnguoi.Text) >= nguoi)
                btBatDau.Visible = true;
        }
        private void demThoiGian()
        {
            int giay = 20; 
            for (int i = giay; i >= 0; i--)
            {
                if (i == 0)
                    lbThoiGian.Text = "";
                else
                    lbThoiGian.Text = i.ToString();
                Thread.Sleep(1000);
            }
            randxingau = new Thread(new ThreadStart(randomXiNgau));
            randxingau.Start();
        }
        private void lacXiNgau()
        {
            xingau1 = rd.Next(1, 7);
            xingau2 = rd.Next(1, 7);
            progressBar1.Increment(6);
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                progressBar1.Value = 0;
                tbTongNut.Text = tongdiem.ToString();
                luot--;
                tbLuot.Text = luot.ToString();
                SendData("nut:" + tongdiem.ToString());
            }
            else
            {
                int kq1 = xingau(xingau1, pictureBox1);
                int kq2 = xingau(xingau2, pictureBox2);
                tongdiem = kq1 + kq2;
            }
        }
        private void btLac_Click(object sender, EventArgs e)
        {
            thoigian.Abort();
            tbDiem.Text = "";
            timer1.Start();
            lbThoiGian.Text = "";
            btLac.Enabled = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lacXiNgau();
        }
        private void btBatDau_Click(object sender, EventArgs e)
        {
            SendData("play");
            btBatDau.Visible = false;
            btLac.Enabled = true;
        }
        void SendData(string content)
        {
            byte[] message = Encoding.UTF8.GetBytes(content);
            socketClient.BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendClientData), socketClient);
        }
        private void SendClientData(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
        private void PlayGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (start == false)
            {
                MessageBox.Show("game đã bắt đầu không thể thoát");
                e.Cancel = true;
            }
            else
            {
                try
                {
                    receive.Abort();
                    thoigian.Abort();
                }
                catch (Exception)
                { }
                th.Start();
            }
        }
        private void btBatDau_EnabledChanged(object sender, EventArgs e)
        {
            if (btBatDau.Enabled == true)
            {
                btBatDau.Enabled = true;
            }
        }

        private void tbUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
