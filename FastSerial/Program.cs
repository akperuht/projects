using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace FastSerial
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FastSerial form1 = new FastSerial();
            form1.Text = "FastSerial 1.01";
            Info info = new Info(true);
            info.Text = "FastSerial 1.01";
            info.Show();
            Application.Run(form1);
        }
    }
}
