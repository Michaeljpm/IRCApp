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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace IRCApp
{
    public partial class Form1 : Form
    {
        public StreamWriter writer;
        
        TcpClient irc;
        Thread IRCThread;
        int Channum = 0;
        public Connect a;
        public string ChanSent;
        public string Nick = "ClientTest1";
        public int x;
        public string Server;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

      

        public void Writebox(string Text)
        {
            
            //writes to listbox
            int SC = 0;
            string[] newText = Text.Split(new Char[] { ' ' });
            char point = '!';
            
            string[] newText1 = newText[0].Split(point);
            char[] namesList = newText[0].ToCharArray();


            if (newText1.Length >= 2)
            {
                Text = Text.Replace(newText1[1], "");
                Regex rgx = new Regex("!");
                Text = rgx.Replace(Text, "", 1);



            }
            if (newText.Length > 3)
                    if (namesList[namesList.Length] == 3 && namesList[namesList.Length-1] == 5 && namesList[namesList.Length - 2] == 3 && newText[1] == "=")
                    {
                        ChanSent = newText[2];
                        Debug.Write("here");
                        foreach(string x in newText)
                        {
                        Debug.Write(x);
                        listBox2[GetTab(1)].Items.Add(x);
                        }
                    
                   
                    
                    
                    }
            if (newText1.Length >= 4)
            {

            }
            if (Text.Contains("PRIVMSG"))
            {
                SC = 1;
                Text = Text.Replace("PRIVMSG", "");
                ChanSent = newText[2];
            }
            if (newText.Length >= 4)
            {
                
                string[] newText2 = newText[2].Split(':');
                ChanSent = newText2[0];
                Text = Text.Replace(newText2[0], "");
                Regex rgx = new Regex(" ");
                Text = rgx.Replace(Text, "", 2);
            }
            if (newText[1] == "JOIN")
            {

                string[] newText2 = newText[2].Split(':');
                if (newText[0].Contains(Nick))
                {
                    ChanSent = newText2[1];
                    AddChan(ChanSent);
                    listBox[GetTab(SC)].Items.Add("NAMES " + ChanSent);
                    listBox[GetTab(0)].Items.Add(listBox[1]);
                }

            }
            
            
            listBox[GetTab(SC)].Items.Add(Text);
            
        }
        
        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MainMsgBox.TopIndex = MainMsgBox.Items.Count - 1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void AddChan(string Channame)
        {
            Invoke(new MethodInvoker(delegate()
            {
                // Creates Tabs
                listBox[Channum] = new ListBox();
                tabPage[Channum] = new TabPage();
                listBox2[Channum] = new ListBox();

                // 
                // MainMsgBox
                // 
                listBox[Channum].FormattingEnabled = true;
                listBox[Channum].HorizontalScrollbar = true;
                listBox[Channum].Location = new System.Drawing.Point(0, 0);
                listBox[Channum].Name = "MainMsgBox";
                listBox[Channum].ScrollAlwaysVisible = true;
                listBox[Channum].SelectionMode = System.Windows.Forms.SelectionMode.None;
                listBox[Channum].Size = new System.Drawing.Size(685, 480);
                listBox[Channum].TabIndex = 0;
                listBox[Channum].SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
                listBox[Channum].FormatStringChanged += new System.EventHandler(this.MainMsgBox_FormatStringChanged);
                listBox[Channum].Enter += new System.EventHandler(this.MainMsgBox_Enter);
                Controls.Add(listBox[Channum]);

                tabPage[Channum].ResumeLayout(false);
                tabControl1.Controls.Add(tabPage[Channum]);
                // 
                // tabPage1
                // 
                tabPage[Channum].Controls.Add(listBox[Channum]);
                tabPage[Channum].Controls.Add(listBox2[Channum]);
                tabPage[Channum].Location = new System.Drawing.Point(4, 22);
                tabPage[Channum].Name = Channame;
                tabPage[Channum].Padding = new System.Windows.Forms.Padding(3);
                tabPage[Channum].Size = new System.Drawing.Size(682, 479);
                tabPage[Channum].TabIndex = 0;
                tabPage[Channum].Text = Channame;
                tabPage[Channum].UseVisualStyleBackColor = true;
                tabPage[Channum].SuspendLayout();

                //
                //listbox2
                //
                listBox2[Channum].FormattingEnabled = true;
                listBox2[Channum].Location = new System.Drawing.Point(690, 0);
                listBox2[Channum].Name = "listBox2";
                listBox2[Channum].Size = new System.Drawing.Size(120, 479);
                listBox2[Channum].TabIndex = 0;
                Channum++;
            }));
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        public int GetTab(int SC)
        {
            //Should choose which tab to write incoming and outgoing messages to
            int ChanSelected = 0;
            if (SC == 1)
            {

                foreach (TabPage x in tabPage)
                {
                    Debug.WriteLine(x);
                    // (tabPage[Array.IndexOf(tabPage,x)].Name == ChanSent)
                    if (x.Name.Split(' ')[0] == ChanSent)
                    
                    {
                        ChanSelected = Array.IndexOf(tabPage, x);
                        return ChanSelected;
                    }
                    //listBox[GetTab(0)].Items.Add(x);

                }
            }
            if (SC == 3)
            {
                
                string ChanString = Convert.ToString(tabControl1.SelectedTab.Name).Split(' ')[0];
                foreach (TabPage x in tabPage)
                {
                    Debug.WriteLine(x);
                    // (tabPage[Array.IndexOf(tabPage,x)].Name == ChanSent)
                    if (x.Name.Split(' ')[0] == ChanString)

                    {
                        ChanSelected = Array.IndexOf(tabPage, x);
                        return ChanSelected;
                    }
                    //listBox[GetTab(0)].Items.Add(x);

                }
                ChanSelected = Convert.ToInt32(ChanString);
            }
            Debug.WriteLine(ChanSelected);
            return ChanSelected;
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
                int SC = 3;
                string[] cmds = new string[] { "!join <Channel>: Joins new channel ", "!nick <nick>: gives new nick" };
                string[] TextBoxText = textBox1.Text.Split(' ');
                if (TextBoxText[0] == "!help")
                {
                    Debug.WriteLine(cmds[0], cmds[1]);
                    string commands = cmds[0] + cmds[1];
                    listBox[GetTab(SC)].Items.Add(commands);
                }
                if (TextBoxText[0] == "!join")
                {
                    string channel = TextBoxText[1];
                    writer.WriteLine("Join " + channel);
                }
                else
                {
                    string ChanString = Convert.ToString(tabControl1.SelectedTab.Name).Split(' ')[0];
                    writer.WriteLine("PRIVMSG " + ChanString + " " + textBox1.Text);
                    writer.Flush();

                    listBox[GetTab(SC)].Items.Add(textBox1.Text);
                    textBox1.Clear();
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        public void button2_click(object sender, EventArgs e)
        {
            AddChan("Main");
            Server = textBox2.Text;
            string Channel = textBox3.Text;
            int Port = 6667;
            string User = "USER CLIENTTEST . . :Testing";
            
            a = new Connect(this);
            if (Server.Length <= 2)
            {
                listBox[GetTab(0)].Items.Add("No Ip");
            }
            else
            {
                irc = new TcpClient(Server, Port);
                NetworkStream stream = irc.GetStream();
                StreamReader reader = new StreamReader(stream);
                writer = new StreamWriter(stream);


                IRCThread = new Thread(() => a.makeConnection(reader, writer, User, Nick, Channel));
                IRCThread.Start();
                
            }
        }

        private void MainMsgBox_Enter(object sender, EventArgs e)
        {

        }

        private void MainMsgBox_FormatStringChanged(object sender, EventArgs e)
        {
            //MainMsgBox.Items.Add("Debug");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}