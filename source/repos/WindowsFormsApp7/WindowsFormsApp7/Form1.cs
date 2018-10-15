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
namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
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

                List<string> msgFilePaths = ((List<string>)folderpath).FindAll(HasMsgExtension);
                List<string> folderPaths = ((List<string>)e.Argument).FindAll(IsDirectory);
                foreach (string folder in folderPaths)
                {
                    msgFilePaths.AddRange(Default.deepSearch
                        ? Directory.GetFiles(folder, "*.msg*", SearchOption.AllDirectories)
                        : Directory.GetFiles(folder, "*.msg*"));
                }
            }
        }

        private static bool HasMsgExtension(string path)
        {
            return (Path.GetExtension(path) == ".msg");
        }

        // Predicate for finding all folders in a list of paths
        private static bool IsDirectory(string path)
        {
            return ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory);
        }


        /*
                private void worker_DoWork(object sender, DoWorkEventArgs e)
                {
                    List<string> msgFilePaths = ((List<string>)e.Argument).FindAll(HasMsgExtension);
                    List<string> folderPaths = ((List<string>)e.Argument).FindAll(IsDirectory);
                    foreach (string folder in folderPaths)
                    {
                        msgFilePaths.AddRange(Default.deepSearch
                            ? Directory.GetFiles(folder, "*.msg*", SearchOption.AllDirectories)
                            : Directory.GetFiles(folder, "*.msg*"));
                    }
                }
        */
    }
}
