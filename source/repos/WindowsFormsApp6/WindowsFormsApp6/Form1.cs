using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                DirectoryInfo theFolder = new DirectoryInfo(foldPath);
                FileInfo[] dirInfo = theFolder.GetFiles();
                //遍历文件夹
                foreach (FileInfo file in dirInfo)
                {
                    MessageBox.Show(file.ToString());
                }
            }
        }

        private static bool HasMsgExtension(string path)
        {
            return (Path.GetExtension(path) == ".msg");
        }

        private static bool IsDirectory(string path)
        {
            return ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Stopwatch timer = new Stopwatch();
            //timer.Start();

            List<string> msgFilePaths = ((List<string>)e.Argument).FindAll(HasMsgExtension);
            List<string> folderPaths = ((List<string>)e.Argument).FindAll(IsDirectory);
        }

    }
}
