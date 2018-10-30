using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace Unreal.Vorbis.Xml
{
    [DebuggerDisplay("{FilePath} ID: {Id}")]
    public class SoundFile
    {
        public SoundFile(XmlNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            Id = uint.Parse(node.Attributes["Id"].Value);
            ShortName = node["ShortName"].InnerText;
            FilePath = node["Path"].InnerText;
        }

        public uint Id { get; private set; }
        private string ShortName { get; set; }
        private string FilePath { get; set; }

        public string ExtractName => Path.GetFileNameWithoutExtension(ShortName) + Path.GetExtension(FilePath);
    }
}
