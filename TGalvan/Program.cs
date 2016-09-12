using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Reflection;
using System.Resources;

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

            string directory = Environment.CurrentDirectory;
            ResourceManager IniConfig = ResourceManager.CreateFileBasedResourceManager("IniConfig", directory + "\\Resources", null);
            string lang = IniConfig.GetString("Idioma");
            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
