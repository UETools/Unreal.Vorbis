using System.Text;
using Unreal.Core;

namespace Unreal.Vorbis.Sections
{
    internal static class FArchiveExtension
    {
        internal static void ReadByteString(this FArchive reader, out string str)
        {
            reader.Read(out byte len);
            reader.Read(out byte[] chars, len);
            str = Encoding.UTF8.GetString(chars);
        }
    }
}
