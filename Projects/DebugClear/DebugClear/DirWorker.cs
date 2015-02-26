using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DebugClear
{
    public class DirWorker
    {
        public List<string> Dirs { get; set; }

        public DirWorker()
        {
            Dirs = new List<string>();
        }

        public FoundDirHandler OnFoundDir;
        public ClearDirHandler OnClearDir;
        private void FoundDir(string Dir)
        {
            if (OnFoundDir != null)
            {
                OnFoundDir(this, new DirEventArgs(Dir));
            }
        }
        private void ClearDir(string Dir)
        {
            if (OnClearDir != null)
            {
                OnClearDir(this, new DirEventArgs(Dir));
            }
        }

        public string RootDir { get; set; }

        public long Size { get; set; }

        public void Search()
        {
            Size = 0L;
            Dirs.Clear();

            DirectoryInfo dir = new DirectoryInfo(RootDir);

            if (String.Compare(dir.Name, "Debug", true) == 0)
            {
                SearchSubDir(dir, true);
            }
            else
            {
                SearchSubDir(dir, false);
            }
        }

        private void SearchSubDir(DirectoryInfo dir, bool isCount)
        {
            if (isCount)
            {
                foreach (FileInfo file in dir.GetFiles())
                {
                    Size += file.Length;
                }
            }

            DirectoryInfo[] subDirs = dir.GetDirectories();
            if (subDirs != null && subDirs.Length > 0)
            {
                foreach (DirectoryInfo subDir in subDirs)
                {
                    if (String.Compare(subDir.Name, "Debug", true) == 0)
                    {
                        Dirs.Add(subDir.FullName);
                        FoundDir(subDir.FullName);
                        SearchSubDir(subDir, true);
                    }
                    else
                    {
                        SearchSubDir(subDir, isCount);
                    }
                }
            }
        }

        public void Clear()
        {
            foreach (string dir in Dirs)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
                {
                    subDir.Delete(true);
                }
                ClearDir(dir);
            }
        }
    }

    public delegate void FoundDirHandler(object sender, DirEventArgs e);

    public delegate void ClearDirHandler(object sender, DirEventArgs e);

    public class DirEventArgs : EventArgs
    {
        public string Dir { get; set; }

        public DirEventArgs(string Dir)
        {
            this.Dir = Dir;
        }
    }
}
