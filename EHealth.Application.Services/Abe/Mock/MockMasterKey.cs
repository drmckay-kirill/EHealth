using EHealth.Application.Services.Abe.Base;

namespace EHealth.Application.Services.Abe.Mock
{
    public class MockMasterKey : IMasterKey
    {
        public byte[] Value { get; set; }
    }
}