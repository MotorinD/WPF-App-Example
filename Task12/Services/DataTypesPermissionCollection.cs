namespace Task12
{
    /// <summary>
    /// Модель для описания доступности полей
    /// </summary>
    internal class DataTypesPermissionCollection
    {
        /// <summary>
        /// Поля относящиеся к ФИО
        /// </summary>
        public PermissionEnum FullName { get; set; }

        /// <summary>
        /// Поля Телефон
        /// </summary>
        public PermissionEnum Phone { get; set; }

        /// <summary>
        /// Поля относящиеся к Паспортным данным
        /// </summary>
        public PermissionEnum Passport { get; set; }
    }
}
