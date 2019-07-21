using System;
using System.Windows;
using System.Windows.Forms;

namespace BalansGUI.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
             
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        public bool DoHandle { get; set; }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            this.DoHandle = true;

            if (this.DoHandle)
            {
                //Handling the exception within the UnhandledExcpeiton handler.
                // MessageBox.Show(e.Exception.Message, "Exception Caught", MessageBoxButton.OK, MessageBoxImage.Error);

                // Get reference to the dialog type.
                var dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg";
                var dialogType = typeof(Form).Assembly.GetType(dialogTypeName);

                // Create dialog instance.
                var dialog = (Form)Activator.CreateInstance(dialogType, new PropertyGrid());

                // Populate relevant properties on the dialog instance.
                dialog.Text = "Exception Caught";
                dialogType.GetProperty("Details").SetValue(dialog, e.Exception.StackTrace, null);
                dialogType.GetProperty("Message").SetValue(dialog, e.Exception.Message, null);

                // Display dialog.
               // var result = dialog.ShowDialog();

                e.Handled = true;
            }
            else
            {
                //If you do not set e.Handled to true, the application will close due to crash.
                //System.Windows.MessageBox.Show("Application is going to close! ", "Uncaught Exception");

                // Get reference to the dialog type.
                var dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg";
                var dialogType = typeof(Form).Assembly.GetType(dialogTypeName);

                // Create dialog instance.
                var dialog = (Form)Activator.CreateInstance(dialogType, new PropertyGrid());

                // Populate relevant properties on the dialog instance.
                dialog.Text = "Application is going to close!";
                dialogType.GetProperty("Details").SetValue(dialog, e.Exception.StackTrace, null);
                dialogType.GetProperty("Message").SetValue(dialog, e.Exception.Message, null);

                // Display dialog.
                var result = dialog.ShowDialog();

                e.Handled = false;
            }
        }


        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            //System.Windows.MessageBox.Show(ex.Message, "Uncaught Thread Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            // Get reference to the dialog type.
            var dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg";
            var dialogType = typeof(Form).Assembly.GetType(dialogTypeName);

            // Create dialog instance.
            var dialog = (Form)Activator.CreateInstance(dialogType, new PropertyGrid());

            // Populate relevant properties on the dialog instance.
            dialog.Text = "Uncaught Thread Exception";
            dialogType.GetProperty("Details").SetValue(dialog, ex.StackTrace, null);
            dialogType.GetProperty("Message").SetValue(dialog, ex.Message, null);

            // Display dialog.
            var result = dialog.ShowDialog();

        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
        }
    }
}


