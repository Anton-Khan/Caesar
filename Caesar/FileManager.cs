using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Caesar
{
    class FileManager
    {

        public FileStream LoadFileStream(string path)
        {
            FileStream file = File.Open(@path, FileMode.Open);
            return file;
        }

        public String LoadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void SaveFile(string path, string text)
        {
            File.WriteAllText(path, text);
        }

    }
}
