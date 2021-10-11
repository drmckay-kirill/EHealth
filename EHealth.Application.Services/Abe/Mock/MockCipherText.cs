using EHealth.Application.Services.Abe.Base;

namespace EHealth.Application.Services.Abe.Mock
{
    public class MockCipherText : ICipherText
    {
        public byte[] Value { get; set; }
    }
}