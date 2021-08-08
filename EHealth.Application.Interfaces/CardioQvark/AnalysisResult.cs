using System.Text.Json.Serialization;

namespace EHealth.Application.Interfaces.CardioQvark
{
    /// <summary>
    /// Результаты анализа ЭКГ в CardioQVARK
    /// </summary>
    public class AnalysisResult
    {
        [JsonPropertyName("cardiogramId")]
        public long CardiogramId { get; set; }

        [JsonPropertyName("error")]
        public int? Error { get; set; }

        [JsonPropertyName("methodId")]
        public string MethodId { get; set; }

        [JsonPropertyName("ts")]
        public int Ts { get; set; }

        [JsonPropertyName("value")]
        public object Value { get; set; }
    };
}
