using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using System.Threading;


namespace IRCApp
{
    
    class Class1 : Connect
    {
        System.Threading.Thread ConnectionThread;
        public void StartThread()
        {
            ConnectionThread = new System.Threading.Thread(new System.Threading.ThreadStart(makeConnection));
            ConnectionThread.Start();
        }
       
    }
}
