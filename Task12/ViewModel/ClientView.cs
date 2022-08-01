using System;
using System.ComponentModel;

namespace Task12
{
    /// <summary>
    /// Представление Клиента для отображения данных в UI
    /// </summary>
    internal class ClientView : IDataErrorInfo
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

        public string Error => throw new NotImplementedException();

        /// <summary>
        /// Описание правил для валидации полей
        /// </summary>
        public string this[string columnName]
        {
            get
            {
                string requeValueMessage = "Обязятельно для заполнения";
                string error = String.Empty;
                switch (columnName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(this.FirstName))
                            error = requeValueMessage;
                        break;

                    case "SecondName":
                        if (string.IsNullOrEmpty(this.SecondName))
                            error = requeValueMessage;
                        break;

                    case "LastName":
                        if (string.IsNullOrEmpty(this.LastName))
                            error = requeValueMessage;
                        break;

                    case "Phone":
                        if (string.IsNullOrEmpty(this.Phone))
                            error = requeValueMessage;
                        break;

                    case "PassSerial":
                        if (string.IsNullOrEmpty(this.PassSerial))
                            error = requeValueMessage;
                        break;

                    case "PassNum":
                        if (string.IsNullOrEmpty(this.PassNum))
                            error = requeValueMessage;
                        break;
                }

                return error;
            }
        }

        public ClientView(Client client)
        {
            this.Id = client.Id;
            this.FirstName = client.FirstName;
            this.SecondName = client.SecondName;
            this.LastName = client.LastName;
            this.Phone = client.Phone;
            this.PassSerial = client.PassSerial;
            this.PassNum = client.PassNum;
        }

        public ClientView(ClientView client)
        {
            if (client is null)
                return;

            this.Id = client.Id;
            this.FirstName = client.FirstName;
            this.SecondName = client.SecondName;
            this.LastName = client.LastName;
            this.Phone = client.Phone;
            this.PassSerial = client.PassSerial;
            this.PassNum = client.PassNum;
        }

        public ClientView() { }
    }
}
