using Microsoft.VisualBasic.ApplicationServices;
using RadfordHr_Controller;

namespace RadfordHr
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            StaffView view = new StaffView();
            StaffController controller = new StaffController(view, new());
            
            controller.LoadView();
            Application.Run(view);
        }
    }
}