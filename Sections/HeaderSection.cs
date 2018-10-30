using Unreal.Core;

namespace Unreal.Vorbis.Sections
{
    class HeaderSection : BankSection
    {
        const int BANK_MAGIC = 0x44484B42; // 'BKHD'
        public override int Magic => BANK_MAGIC;

        private int Version { get; set; }
        public uint SoundBankID { get; private set; }

        public override void Serialize(FArchive reader)
        {
            base.Serialize(reader);

            reader.Read(out int _version);
            reader.Read(out uint Id);
            Version = _version;
            SoundBankID = Id;
        }
    }
}
