using System;
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

namespace IRCApp
{
    public partial class Form1 : Form
    {
        public StreamWriter writer;
        TcpClient irc;
        Thread IRCThread;

        public Connect a;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
                writer.WriteLine("PRIVMSG " + a.Channel + " " + textBox1.Text);
                writer.Flush();

                MainMsgBox.Items.Add("Debug: " + "PRIVMSG " + a.Channel + " " + textBox1.Text);
                textBox1.Clear();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_click(object sender, EventArgs e)
        {

            string Server = "4bit.pw";
            int Port = 6667;
            string User = "USER CLIENTTEST . . :Testing";
            string Nick = "ClientTest1";

            a = new Connect(this);

            irc = new TcpClient(Server, Port);
            NetworkStream stream = irc.GetStream();
            StreamReader reader = new StreamReader(stream);
            writer = new StreamWriter(stream);


            IRCThread = new Thread(() => a.makeConnection(reader, writer, User, Nick));
            IRCThread.Start();
        }

        
    }
}