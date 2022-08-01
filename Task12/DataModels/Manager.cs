namespace Task12
{
    /// <summary>
    /// Модель данных пользователя типа Менеджер
    /// </summary>
    internal class Manager : User
    {
        /// <summary>
        /// Права для взаимодействия с полями для пользователя данного типа 
        /// </summary>
        public override DataTypesPermissionCollection GetPermission()
        {
            return new DataTypesPermissionCollection
            {
                FullName = PermissionEnum.FullAllow,
                Passport = PermissionEnum.FullAllow,
                Phone = PermissionEnum.FullAllow
            };
        }

        /// <summary>
        /// Может добавлять данные
        /// </summary>
        public override bool IsCanAddData() => true;

        /// <summary>
        /// Описание процесса сохранения данных модели Клиент для пользователя данного типа 
        /// </summary>
        public override void ModifyClientData(Client client, ClientView view)
        {
            client.WhoChanged = "Менеджер";

            client.FirstName = view.FirstName;
            client.SecondName = view.SecondName;
            client.LastName = view.LastName;
            client.Phone = view.Phone;
            client.PassSerial = view.PassSerial;
            client.PassNum = view.PassNum;

            base.ModifyClientData(client, view);
        }

        /// <summary>
        /// Описание изменений представления Клиента для пользователя данного типа 
        /// </summary>
        public override void ModifyClientView(ClientView view) { }
    }
}
