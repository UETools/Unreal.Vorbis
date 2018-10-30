using Unreal.Core;

namespace Unreal.Vorbis.Sections
{
    partial class HIRCSection : BankSection
    {
        const int HIRC_MAGIC = 0x43524948; // 'HIRC'
        public override int Magic => HIRC_MAGIC;

        public override void Serialize(FArchive reader)
        {
            base.Serialize(reader);
            //var count = reader.ToInt32();
            //foreach (var i in Enumerable.Range(0, count))
            //{
            //}
        }
    }
}
