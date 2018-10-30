using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Unreal.Vorbis.Xml
{
    public class SoundBank : SoundFile
    {
        List<SoundFile> MemoryFiles { get; set; }

        public SoundBank(XmlNode node) : base(node)
        {
            var files = node.SelectNodes(".//IncludedMemoryFiles/*");
            MemoryFiles = new List<SoundFile>(files.Count);
            foreach (XmlNode file in files)
                MemoryFiles.Add(new SoundFile(file));
        }

        public SoundFile GetFile(uint trackId) => MemoryFiles.SingleOrDefault(file => file.Id == trackId);
    }
}
