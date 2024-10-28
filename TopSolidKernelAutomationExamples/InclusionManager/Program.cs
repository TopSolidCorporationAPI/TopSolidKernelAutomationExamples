using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TopSolid.Kernel.Automating;
using TopSolid.Cad.Design.Automating;

namespace InclusionManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TopSolidHost.Connect();
            TopSolidDesignHost.Connect();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            TopSolidHost.Disconnect();
            TopSolidDesignHost.Disconnect();
        }
    }
}
