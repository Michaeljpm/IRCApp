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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Connect a = new Connect(this);
            InitializeComponent();
            var IRCThread = new Thread(new ThreadStart(a.makeConnection));
            IRCThread.Start();
            
            
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

        
        

    }
}
