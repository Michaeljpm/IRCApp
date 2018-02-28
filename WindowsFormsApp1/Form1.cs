using System;
using IRCApp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Connect c;

        public Form1()
        {
            InitializeComponent();
            Connect c = new Connect(this);
            WriteMsg("Hello");
            c.makeConnection();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void WriteMsg(string Text)
        {
            MainMsgBox.Items.Add(Text);
            
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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.ComponentModel.BackgroundWorker worker;
            worker = (System.ComponentModel.BackgroundWorker)sender;
            Connect connect = (Connect)e.Argument;
            
            
        }
        public void StartThread()
        {
           Connect c1 = this.c;


        }

    }
}
