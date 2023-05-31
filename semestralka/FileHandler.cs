using System.IO;

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
