using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//TopSolid Automation Kernel
using TopSolid.Kernel.Automating;

namespace RevisionManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Automation connection
            //if topsolid is not running, then app will launch latest version installed on single local machine
            //for more informations on connection, please refer to topsolid design automation guide
            TopSolidHost.Connect();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //disconnect host when application is closed
            TopSolidHost.Disconnect();

        }
    }
}
