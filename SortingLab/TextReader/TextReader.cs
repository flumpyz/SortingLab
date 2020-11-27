using System.IO;
using System.Text;

namespace SortingLab.TextReader
{
    public static class TextReader
    {
        public static string GetText(Stream stream)
        {
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int) stream.Length);
            return Encoding.Default.GetString(buffer);
        }
    }
}
