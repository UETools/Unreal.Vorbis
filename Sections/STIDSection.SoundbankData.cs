using Unreal.Core;

namespace Unreal.Vorbis.Sections
{
    partial class STIDSection
    {
        public class SoundbankData : IUnrealDeserializable
        {
            public uint Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }

            public void Deserialize(FArchive reader)
            {
                reader.Read(out _id);
                reader.ReadByteString(out _name);
            }

            private uint _id;
            private string _name;
        }
    }
}
