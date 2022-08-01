using System;

namespace Task12
{
    /// <summary>
    /// Модель данных Клиент
    /// </summary>
    internal class Client
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Паспорт серия
        /// </summary>
        public string PassSerial { get; set; }

        /// <summary>
        /// Паспорт номер
        /// </summary>
        public string PassNum { get; set; }

        /// <summary>
        /// Дата изменения записи
        /// </summary>
        public string DateTimeChanged { get; set; }

        /// <summary>
        /// Перечень измененных полей
        /// </summary>
        public string DataFieldChanged { get; set; }

        /// <summary>
        /// Кто внес изменения
        /// </summary>
        public string WhoChanged { get; set; }

        public Client()
        {
            this.Id = 0;
            this.FirstName = String.Empty;
            this.SecondName = String.Empty;
            this.LastName = String.Empty;
            this.Phone = String.Empty;
            this.PassSerial = String.Empty;
            this.PassNum = String.Empty;
        }

        public Client(ClientView editedView)
        {
            this.Id = 0;
            this.FirstName = editedView.FirstName;
            this.SecondName = editedView.SecondName;
            this.LastName = editedView.LastName;
            this.Phone = editedView.Phone;
            this.PassSerial = editedView.PassSerial;
            this.PassNum = editedView.PassNum;
        }
    }
}
