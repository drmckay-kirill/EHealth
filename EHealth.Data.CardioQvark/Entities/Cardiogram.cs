namespace EHealth.Data.CardioQvark.Interfaces.Entities
{
    /// <summary>
    /// Сущность данных кардиограммы, полученной из API CardioQVARK
    /// </summary>
    /// <param name="DeviceNumber">Серийный номер устройства</param>
    /// <param name="PatientId">Уникальный идентификатор пациента в CardioQVARK</param>
    /// <param name="CardiogramId">Уникальный идентификатор кардиограммы в CardioQVARK</param>
    /// <param name="method">Наименование метода распознования ЭКГ</param>
    /// <param name="data">Набор распознанных данных</param>
    /// <param name="dataView">Набор распознанных данных в виде строки</param>
    public record Cardiogram(
        string DeviceNumber,
        string PatientId,
        long CardiogramId,
        string method,
        byte[] data,
        string dataView
        );
}
