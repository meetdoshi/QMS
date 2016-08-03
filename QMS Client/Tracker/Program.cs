using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //jump to existing process if exist.
            //if (AppRunning.AlreadyRunning()) 
            //    return;

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new  Login());
        }
    }
}
