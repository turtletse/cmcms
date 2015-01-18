using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CMCMS
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
            //Application.Run(new DrugAdmin());
            //Application.Run(new Patient_newPatient());
            //Application.Run(new Patient_amdPatientData());
            //Application.Run(new Patient_mainMenu());
            //Application.Run(new AddFormulaForm());
            Application.Run(new Login());
        }
    }
}
