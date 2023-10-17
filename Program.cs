using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MultiFaceRec
{
    static class Program
    {
        public static int mode;
        public static string username;
        public static bool otpverification;
       
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmPrincipal());
            Application.Run(new LoginScreen());
           // Application.Run(new OtpVerfication());
            
        }
    }
}
