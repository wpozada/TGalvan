using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using System.IO;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Drawing;

namespace TGalvan
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>       
        [STAThread]
        static void Main()
        {
            //Error variable to check it's the program run ok
            bool error = false;
            //Directory of app
            string directory = Environment.CurrentDirectory;
            ResourceManager IniConfig;
            CultureInfo CI;
            Assembly TGalvan_asm;
            ResourceManager TGalvan_rsc = null;
            try
            {
                //Search the initial resources of the app for apply those settings
                IniConfig = ResourceManager.CreateFileBasedResourceManager("IniConfig", directory + "\\Resources", null);
                string lang = IniConfig.GetString("Idioma");
                //Set the culture, the assembly and the resources asociated with it
                CI = new CultureInfo(lang);
                Thread.CurrentThread.CurrentCulture = CI;
                Thread.CurrentThread.CurrentUICulture = CI;
                TGalvan_asm = Assembly.LoadFrom(directory + "\\Resources\\" + lang + "TGalvan.resources.dll");
                TGalvan_rsc = new ResourceManager("TGalvan", TGalvan_asm);
            }
            catch
            {
                MessageBox.Show("There is a problem loading the initial configuration ","Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                error = true;
            }
            if (error == false)
            {
                Stream TGlogo = TGalvan_rsc.GetStream("tecnologiagalvan");
                Stream Clogo = TGalvan_rsc.GetStream("cliente_logo");
                Icon TGicon = (Icon)TGalvan_rsc.GetObject("GALVAN");
                Start Inicio = new Start();
                Inicio.pictureBox1.Image = new Bitmap(TGlogo);
                Inicio.pictureBox2.Image = new Bitmap(Clogo);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(Inicio);
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    Inicio.progressBar1.PerformStep();
                }
            }
            
        }
    }
}
