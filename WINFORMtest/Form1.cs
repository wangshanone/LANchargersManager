using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sodao.FastSocket.Server;
using Sodao.FastSocket.Server.Messaging;
using Sodao.FastSocket.SocketBase;
namespace WINFORMtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SocketServerManager.Init();
            SocketServerManager.Start();
        }
    }
    
    public class MyService : AbsSocketService<CommandLineMessage>
    {
        public override void OnConnected(IConnection connection)
        {
            base.OnConnected(connection);
            Console.WriteLine(connection.RemoteEndPoint.ToString() + " " + connection.ConnectionID.ToString() + " connected");
            connection.BeginReceive();
        }

        public override void OnReceived(IConnection connection, CommandLineMessage message)
        {
            base.OnReceived(connection, message);

            message.Reply(connection, "123");

        }

        public override void OnDisconnected(IConnection connection, Exception ex)
        {
            base.OnDisconnected(connection, ex);
            Console.WriteLine(connection.RemoteEndPoint.ToString() + " disconnected");
        }

        public override void OnException(IConnection connection, Exception ex)
        {
            base.OnException(connection, ex);
            Console.WriteLine(ex.ToString());
        }
    }





}
