using System;
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
        public static string Server = "4bit.pw";
        private static int Port = 6667;
        private static string User = "USER CLIENTTEST . . :Testing";
        private static string Nick = "ClientTest1";
        private static string Channel = "#M_";
        public static StreamWriter writer;
        private Form1 form1;

        
        public Connect(Form1 form1) 
        {
            this.form1 = form1;
        }

        

        public Connect()
        {

        }

        public void makeConnection()
        {

           
            form1.WriteMsg("test");
            NetworkStream stream;
            TcpClient irc;
            string inputLine;
            StreamReader reader;
            string nickname;
            
            try
            {
                irc = new TcpClient(Server, Port);
                stream = irc.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);
                writer.WriteLine("NICK " + Nick);
                writer.Flush();
                writer.WriteLine(User);
                writer.Flush();
                while (true)
                {
                    while ((inputLine = reader.ReadLine())!= null)
                    {
                        form1.WriteMsg("<-" + inputLine);
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
                                string JoingString = "JOIN" + Channel;
                                writer.WriteLine(JoingString);
                                writer.Flush();
                                break;
                            default:
                                break;

                        }
                    }
                    writer.Close();
                    reader.Close();
                    irc.Close();
                    //return true;
                }

            }
            catch (Exception e)
            {
                form1.WriteMsg(e.ToString());
                form1.WriteMsg("test2");
                Thread.Sleep(5000);
                string[] argv = { };
                //return false;
            }
        }
    }
}
