namespace Unreal.Vorbis
{
    partial class BankFile
    {
        public class BankTrack
        {
            public uint Id { get; set; }
            public int Offset { get; set; }
            public int Length { get; set; }

            public string Name => Id.ToString() + ".wem";
        }
    }
}
