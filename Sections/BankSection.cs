using Unreal.Core;

namespace Unreal.Vorbis.Sections
{
    abstract class BankSection
    {
        public abstract int Magic { get; }

        public int Length { get; private set; }
        public long SectionStart { get; private set; }
        public long SectionEnd => SectionStart + Length;

        public virtual void Serialize(FArchive reader)
        {
            reader.Read(out int _len);
            Length = _len;
            SectionStart = reader.Tell();
        }
    }
}
