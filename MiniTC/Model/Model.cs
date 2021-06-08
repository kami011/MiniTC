using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MiniTotalCommander.ViewModel
{
    class Model
    {
        public string[] getDrives()
        {
            return Directory.GetLogicalDrives();
        }

        public string[] getFiles(string path)
        {
            List<string> Files = new List<string>();
            try
            {
                if (Directory.GetParent(path) != null) Files.Add("...");

                for (int i = 0; i < Directory.GetDirectories(path).Length; i++)
                {
                    Files.Add("<D>" + Path.GetFileName(Directory.GetDirectories(path)[i]));
                }

                for (int i = 0; i < Directory.GetFiles(path).Length; i++)
                {
                    Files.Add(Path.GetFileName(Directory.GetFiles(path)[i]));
                }
            }
            catch { }
            return Files.ToArray();
        }

        public string setPath(string path, string selected)
        {
                if (selected != null && selected.Substring(0, 3) == "<D>")
                {
                    selected = selected.Replace("<D>", "");
                    string newPath = Path.Combine(path, selected);
                    return newPath;
                }

                if (selected == "...")
                {
                    string newPath = Directory.GetParent(path).FullName;
                    return newPath;
                }
            return path;
        }

        public void copy(string srcPath, string dstPath)
        {
            try
            {
                File.Copy(srcPath, dstPath);
            }
            catch { }
        }

    }
}
