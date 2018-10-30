using Unreal.Core;

namespace Unreal.Vorbis.Sections
{
    class DataSection : BankSection
    {
        const int DATA_MAGIC = 0x41544144; // 'DATA'
        public override int Magic => DATA_MAGIC;

        public override void Serialize(FArchive reader) => base.Serialize(reader);
    }
}
