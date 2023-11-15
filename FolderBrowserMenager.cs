using System.Windows.Forms;
using System;
namespace ConsoleApp13
{
    public static class FolderBrowserMenager
    {
        public static string SelectFolderLocation()
        {
            var dialogbox = new FolderBrowserDialog();
            var result = dialogbox.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    if (string.IsNullOrEmpty(dialogbox.SelectedPath))
                    {
                        throw new Exception("Please select a valid location");
                    }
                    return dialogbox.SelectedPath;
                    
                default:
                    throw new Exception("unknow operation");
            }
        }
    }
}
