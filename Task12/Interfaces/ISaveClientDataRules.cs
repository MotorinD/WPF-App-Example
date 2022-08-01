namespace Task12
{
    /// <summary>
    /// Описание процесса сохранения данных из представления
    /// </summary>
    internal interface ISaveClientDataRules
    {
        /// <summary>
        /// Сохранение данных из представления Клиент в соответсвующую модель данных согласно описанию
        /// </summary>
        public void ModifyClientData(Client client, ClientView view);
    }
}
