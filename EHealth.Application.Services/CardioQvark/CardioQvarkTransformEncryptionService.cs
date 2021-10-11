using System.Text.Json;
using System.Threading.Tasks;
using EHealth.Application.Interfaces.CardioQvark;
using EHealth.Application.Services.Abe.Base;
using EHealth.Application.Services.Abe.Mock;

namespace EHealth.Application.Services.CardioQvark
{
    public class CardioQvarkTransformEncryptionService : ICardioQvarkTransform
    {
        private readonly ICPAbe _abe = new MockCPAbe();

        private readonly object _lockKeySetup = new();
        private SetupResult _keys;

        public async Task<byte[]> Transform(object result, string[] accessPolicy)
        {
            SetupKeys();

            var policy = new MockAttributes(accessPolicy);
            var jsonMessage = JsonSerializer.Serialize(result);
            var encryptedMessage = await _abe.Encrypt(jsonMessage, _keys.PublicKey, policy);

            return encryptedMessage.Value;
        }

        private void SetupKeys()
        {
            if (_keys is not null)
                return;

            lock (_lockKeySetup)
            {
                _keys = _abe.Setup().GetAwaiter().GetResult();
            }
        }
    }
}