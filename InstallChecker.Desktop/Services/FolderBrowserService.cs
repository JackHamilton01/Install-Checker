using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstallChecker.Desktop.Services
{
    public class FolderBrowserService
    {
        public string OpenFileExplorer()
        {
            string path;
            //var dialog = new Ookii.Dialogs.Wpf.VistaF olderBrowserDialog();
            var dialog = new VistaOpenFileDialog();

            if (dialog.ShowDialog().GetValueOrDefault())
            {
                return path = dialog.FileName;
            }
            else
            {
                return path = string.Empty;
            }
        }
    }
}
