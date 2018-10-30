using System.Collections.Generic;
using System.Linq;
using Unreal.Core;

namespace Unreal.Vorbis.Sections
{
    partial class STIDSection : BankSection
    {
        const int STID_MAGIC = 0x44495453; // 'STID'
        public override int Magic => STID_MAGIC;

        public List<SoundbankData> Soundbanks { get; } = new List<SoundbankData>();

        public override void Serialize(FArchive reader)
        {
            base.Serialize(reader);
            reader.Read(out int unkn);
            reader.Read(out int count);
            foreach (var i in Enumerable.Range(0, count))
            {
                reader.Read(out SoundbankData data);
                Soundbanks.Add(data);
            }
        }
    }
}
