using System;
using System.Collections.Generic;
using System.Linq;
using Unreal.Core;
using Unreal.Vorbis.Sections;

namespace Unreal.Vorbis
{
    partial class BankFile : IDisposable
    {
        const int BANK_MAGIC = 0x44484B42; // 'BKHD'
        const int DIDX_MAGIC = 0x58444944; // 'DIDX'
        const int DATA_MAGIC = 0x41544144; // 'DATA'
        const int STID_MAGIC = 0x53544944; // 'STID'
        const int HIRC_MAGIC = 0x43524948; // 'HIRC'

        public uint ID => Header.SoundBankID;
        public List<BankTrack> Files => DataIndex.Files;

        public BankFile(byte[] Data)
        {
            reader = Data;
            while (!reader.EOF())
            {
                reader.Read(out int Magic);
                if (Sections.TryGetValue(Magic, out var section))
                {
                    section.Serialize(reader);
                    reader.Seek(section.SectionEnd);
                }
                else
                {
                    reader.Read(out int len);
                    reader.Skip(len);
                }
            }
        }
        public Memory<byte> ReadTrack(BankTrack track) => reader.RawBuffer.Slice((int)Data.SectionStart + track.Offset, track.Length);

        public void Dispose()
        {
            Files.Clear();
            reader.Dispose();
        }

        Dictionary<int, BankSection> Sections = typeof(BankSection).Assembly.GetTypes()
            .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(BankSection)))
            .Select(t => Activator.CreateInstance(t) as BankSection)
            .ToDictionary(s => s.Magic);

        private FArchive reader;

        private HeaderSection Header => Sections[BANK_MAGIC] as HeaderSection;
        private DataIndexSection DataIndex => Sections[DIDX_MAGIC] as DataIndexSection;
        private DataSection Data => Sections[DATA_MAGIC] as DataSection;
    }
}
