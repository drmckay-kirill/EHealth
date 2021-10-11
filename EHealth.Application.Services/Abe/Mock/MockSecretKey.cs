using EHealth.Application.Services.Abe.Base;

namespace EHealth.Application.Services.Abe.Mock
{
    public class MockSecretKey : ISecretKey
    {
        public byte[] Value { get; set; }
    }
}