using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DebugClear
{
    public partial class FormMain : Form
    {
        DirWorker worker = new DirWorker();

        public FormMain()
        {
            InitializeComponent();

            worker.OnFoundDir = new FoundDirHandler(OnFoundDir);
            worker.OnClearDir = new ClearDirHandler(OnClearDir);
        }

        private void btnSelectDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            dialog.Description = "请选择一个目录用来搜索";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                cmbDir.Text = dialog.SelectedPath;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbDir.Text))
                return;

            Thread thread = new Thread(new ThreadStart(StartSearch));
            thread.Start();
            labelSize.Text = worker.Size + " Bytes";
        }

        private void StartSearch()
        {
            worker.RootDir = GetText();
            worker.Search();
            SetSize(worker.Size + " Bytes");
            AppendText("Search finish");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbDir.Text))
                return;

            Thread thread = new Thread(new ThreadStart(StartClear));
            thread.Start();
        }

        private void StartClear()
        {
            worker.Clear();
            AppendText("Clear finish");
        }

        private void OnFoundDir(object sender, DirEventArgs e)
        {
            AppendText("Found: " + e.Dir);
        }

        private void OnClearDir(object sender, DirEventArgs e)
        {
            AppendText("Clear: " + e.Dir);
        }

        private string GetText()
        {
            if (cmbDir.InvokeRequired)
            {
                GetTextCallback d = new GetTextCallback(GetText);
                return (string)this.Invoke(d);
            }
            else
                return cmbDir.Text;
        }

        private void AppendText(string Text)
        {
            if (listBoxResult.InvokeRequired)
            {
                AppendTextCallback d = new AppendTextCallback(AppendText);
                this.Invoke(d, new object[] { Text });
            }
            else
                listBoxResult.Items.Add(Text);
        }

        private void SetSize(string Text)
        {
            if (labelSize.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetSize);
                this.Invoke(d, new object[] { Text });
            }
            else
                labelSize.Text = Text;
        }
    }

    public delegate string GetTextCallback();

    public delegate void AppendTextCallback(string Text);

    public delegate void SetTextCallback(string Text);
}
