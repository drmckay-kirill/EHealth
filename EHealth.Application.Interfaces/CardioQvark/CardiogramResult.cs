using System.Text.Json.Serialization;

namespace EHealth.Application.Interfaces.CardioQvark
{
    /// <summary>
    /// Данные по кардиограмме из API CardioQVARK
    /// </summary>
    public class CardiogramResult
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("accountId")]
        public long AccountId { get; set; }

        [JsonPropertyName("deviceSerial")]
        public string DeviceSerial { get; set; }
    }
}
