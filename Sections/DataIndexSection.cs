using System.Collections.Generic;
using System.Linq;
using Unreal.Core;

namespace Unreal.Vorbis.Sections
{
    class DataIndexSection : BankSection
    {
        const int DIDX_MAGIC = 0x58444944; // 'DIDX'

        // 0x0 Track ID
        // 0x4 Offset
        // 0x8 Data Length
        const int ENTRY_SIZE = 0xC;
        public override int Magic => DIDX_MAGIC;
        public List<BankFile.BankTrack> Files { get; } = new List<BankFile.BankTrack>();

        public override void Serialize(FArchive reader)
        {
            base.Serialize(reader);

            var filecount = Length / ENTRY_SIZE;
            foreach (var i in Enumerable.Range(0, filecount))
            {
                reader.Read(out uint trackId);
                reader.Read(out int offset);
                reader.Read(out int _len);
                Files.Add(new BankFile.BankTrack() {
                    Id = trackId,
                    Offset = offset,
                    Length = _len,
                });
            }
        }
    }
}
