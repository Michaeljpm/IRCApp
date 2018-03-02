﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using WindowsFormsApp1;

namespace IRCApp 
{
    class Connect
    {
        public string inputLine;
        public string Channel = "#M_";
        private Form1 form1;


        public Connect(Form1 frm)
        {
            form1 = frm;
        }

        public void makeConnection(StreamReader reader, StreamWriter writer, string User, string Nick)
        {
            //string nickname;
            try
            {
                writer.WriteLine("NICK " + Nick);
                writer.Flush();
                writer.WriteLine(User);
                writer.Flush();
                while (true)
                {
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        form1.WriteMsg(inputLine);
                        string[] splitInput = inputLine.Split(new Char[] { ' ' });
                        if(splitInput[0] =="PING")
                        {
                            string PongRelpy = splitInput[1];
                            writer.WriteLine("PONG" + PongRelpy);
                            writer.Flush();
                            continue;
                        }
                        switch(splitInput[1])
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
            //catch (Exception e)
            //{
            //    //form1.WriteMsg(e.ToString());
            //    //form1.WriteMsg("test2");
            //    Thread.Sleep(5000);
            //    string[] argv = { };
                
            //}
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
