using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;


namespace IRCApp
{
    public class Connect
    {
        public string inputLine;
        public string Channel = "#M_";

        public Form1 mainForm;
        public Connect(Form1 mainfm)
        {

            mainForm = mainfm;
        }

        public async void makeConnection(StreamReader reader, StreamWriter writer, string User, string Nick)
        {
            try
            {
                writer.WriteLine("NICK " + Nick);
                writer.Flush();
                writer.WriteLine(User);
                writer.Flush();
                while (true)
                {
                    while ((inputLine = await reader.ReadLineAsync()) != null)
                    {
                        mainForm.Invoke(new MethodInvoker(delegate ()
                        {
                            mainForm.MainMsgBox.Items.Add(inputLine);
                        }));
                        string[] splitInput = inputLine.Split(new Char[] { ' ' });
                        if (splitInput[0] == "PING")
                        {
                            string PongRelpy = splitInput[1];
                            writer.WriteLine("PONG" + PongRelpy);
                            writer.Flush();
                            continue;
                        }
                        switch (splitInput[1])
                        {
                            case "001":
                                string JoingString = "JOIN " + Channel;
                                writer.WriteLine(JoingString);
                                writer.Flush();
                                break;
                            default:
                                break;
                        }
                    }
                    writer.Close();
                    reader.Close();
                }
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}