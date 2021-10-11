using EHealth.Application.Services.Abe.Base;

namespace EHealth.Application.Services.Abe.Mock
{
    public class MockPublicKey : IPublicKey
    {
        public byte[] Value { get; set; }
    }
}