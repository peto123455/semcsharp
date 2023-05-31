using System.IO;

namespace semestralka.FileHandler
{
    internal abstract class FileHandler
    {
        protected Stream FileStream;

        protected FileHandler(Stream fileStream)
        {
            FileStream = fileStream;
        }

        public virtual void Close()
        {
            FileStream.Close();
        }
    }
}
