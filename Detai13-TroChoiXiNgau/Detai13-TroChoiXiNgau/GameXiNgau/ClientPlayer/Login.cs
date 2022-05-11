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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace ClientPlayer
{
    public partial class Login : Form
    {
        private Socket socketCl; 
        private string username = "";
        int recv;
        private byte[] data = new byte[1024];
        PlayGame play = new PlayGame();

        public Login()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            socketCl = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 100);
            socketCl.BeginConnect(ipep, new AsyncCallback(Connected), socketCl);
            play.socketClient = socketCl;
            SendData(socketCl,"");
        }
        public void openNewForm()
        {
            play.username = username;
            play.th = new Thread(new ThreadStart(clo));
            play.Show();
            this.Hide();
        }
        Thread th;
        private void clo()
        {
            this.Close();
        }
        void ReceiveDataFromServer()
        {
            string mess;
            recv = socketCl.Receive(data);
            mess = Encoding.UTF8.GetString(data, 0, recv);
            if (mess == "user")
            {
                MessageBox.Show("Đã có người dùng");
                return;
            }
            else if (mess == "thanhcong")
            {
                username = tbDangNhap.Text;
                showform();
            }
            else if (mess == "dangchoi")
            {
                MessageBox.Show("Đã bắt đầu chò chơi");
                return;
            }
            else if (mess == "du")
            {
                MessageBox.Show("Đã đủ người chơi");
                return;
            }
            username = tbDangNhap.Text;
        }
        private void showform()
        {
            play.username = username;
            play.th = new Thread(new ThreadStart(clo));
            play.Show();
            this.Hide();
        }
        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            if (tbDangNhap.Text != "" && tbEmail.Text != "" && tbDangNhap.Text.Length < 10 && isEmail(tbEmail.Text) == true)
            {
                SendData(socketCl, "user:" + tbDangNhap.Text + ":" + tbEmail.Text);
                ReceiveDataFromServer();
            }
            else
            {
                MessageBox.Show("email hoặc tài khoản không hợp lệ");
            }
        }
        private void tbDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        void Connected(IAsyncResult iar)
        {
            try
            {
                socketCl.EndConnect(iar);
                lbConnect.ForeColor = Color.Green;
                lbConnect.Text = "Đã kết nối tới máy chủ";
            }
            catch (SocketException)
            {
                lbConnect.Text = "Lỗi không thể kết nối tới máy chủ";
            }
        }
        void SendData(Socket socket, string content)
        {
            byte[] data = Encoding.UTF8.GetBytes(content);
            try
            {
                socket.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendClientData), socket);
            }
            catch (Exception) { }
        }
        private void SendClientData(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendData(socketCl,"exit:" + username);
            try
            {
                th.Abort();
            }
            catch (Exception) { }
        }
    }
}
