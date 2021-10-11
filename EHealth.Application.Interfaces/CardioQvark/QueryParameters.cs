namespace EHealth.Application.Interfaces.CardioQvark
{
    /// <summary>
    /// Параметры запроса сведений в API CardioQVARK
    /// </summary>
    /// <param name="DeviceNumber">Серийный номер</param>
    /// <param name="PatientId">Уникальный идентификатор пациента в CardioQVARK</param>
    /// <param name="Offset">Минимальный номер кардиограммы, после которой пойдёт поиск</param>
    /// <param name="AccessPolicy">Политики доступа для шифрования данных</param>
    public record QueryParameters(string DeviceNumber, string PatientId, long? Offset, string[] AccessPolicy);
}
