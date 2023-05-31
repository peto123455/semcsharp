using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semestralka
{
    abstract class FileHandler
    {
        protected Stream fileStream;

        public FileHandler(Stream fileStream)
        {
            this.fileStream = fileStream;
        }

        public virtual void Close()
        {
            fileStream.Close();
        }
    }
}
