namespace EHealth.Application.Interfaces.CardioQvark
{
    public class ExtractResult
    {
        public long CardiogramId { get; set; }

        public int? Error { get; set; }

        public string MethodId { get; set; }

        public int Ts { get; set; }

        public object Value { get; set; }

        public byte[] EncryptedValue { get; set; }
        
        public long AccountId { get; set; }

        public string DeviceSerial { get; set; }
    }
}
