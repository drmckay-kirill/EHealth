namespace EHealth.Data.CardioQvark.Interfaces.Entities
{
    /// <summary>
    /// Сущность данных кардиограммы, полученной из API CardioQVARK
    /// </summary>
    public class Cardiogram
    {
        /// <summary>
        /// Серийный номер устройства
        /// </summary>
        public string DeviceNumber { get; set; }

        /// <summary>
        /// Уникальный идентификатор пациента в CardioQVARK
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// Уникальный идентификатор кардиограммы в CardioQVARK
        /// </summary>
        public long CardiogramId { get; set; }

        /// <summary>
        /// Наименование метода распознования ЭКГ
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Набор распознанных данных
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Набор распознанных данных в виде строки
        /// </summary>
        public string DataView { get; set; }
    }
}
