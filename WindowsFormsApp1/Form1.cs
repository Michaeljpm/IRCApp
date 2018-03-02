using System;
using IRCApp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        StreamWriter writer;
        

        public Form1()
        {
           
            InitializeComponent();
            
            
            

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void WriteMsg(string Text)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                MainMsgBox.Items.Add(Text);
            }));
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            void WriteBox(string Text)
            {

                MainMsgBox.Items.Add(Text);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                string Text1 = textBox1.Text;
                Connect c = new Connect(this);
                writer.WriteLine("PRIVMSG " + c.Channel + " " + Text1);

                
                WriteMsg("Debug: " + "PRIVMSG " + c.Channel + " " + Text1);
                textBox1.Clear();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            Connect a = new Connect(this);
            string Server = "4bit.pw";
            int Port = 6667;
            string User = "USER CLIENTTEST . . :Testing";
            string Nick = "ClientTest1";

            
            TcpClient irc = new TcpClient(Server, Port);
            NetworkStream stream = irc.GetStream();
            StreamReader reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            
        Thread IRCThread = new Thread(() => a.makeConnection(reader, writer, User, Nick));
            
            IRCThread.Start();
        }
    }
}
