using System.IO;
using System.Text;

namespace SortingLab
{
    public static class StreamExtension
    {
        public static void StreamWrite(this Stream stream, string text = null)
        {
            stream.Write(Encoding.Default.GetBytes($"{text}"), 0, text.Length);
        }

        public static void StreamWriteLine(this Stream stream, string text = null)
        {
            stream.Write(Encoding.Default.GetBytes($"{text}\r\n"), 0, text.Length + 2);
        }
    }
}
