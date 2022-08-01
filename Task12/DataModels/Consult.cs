namespace Task12
{
    /// <summary>
    /// Модель данных пользователя типа Консультант
    /// </summary>
    internal class Consult : User
    {
        /// <summary>
        /// Права для взаимодействия с полями для пользователя данного типа 
        /// </summary>
        public override DataTypesPermissionCollection GetPermission()
        {
            return new DataTypesPermissionCollection
            {
                FullName = PermissionEnum.ReadOnly,
                Passport = PermissionEnum.ReadOnly,
                Phone = PermissionEnum.FullAllow
            };
        }

        /// <summary>
        /// Может добавлять данные
        /// </summary>
        public override bool IsCanAddData() => false;

        /// <summary>
        /// Описание процесса сохранения данных модели Клиент для пользователя данного типа 
        /// </summary>
        public override void ModifyClientData(Client client, ClientView view)
        {
            client.WhoChanged = "Консультант";
            client.Phone = view.Phone;

            base.ModifyClientData(client, view);
        }

        /// <summary>
        /// Описание изменений представления Клиента для пользователя данного типа 
        /// </summary>
        public override void ModifyClientView(ClientView view)
        {
            if (!string.IsNullOrEmpty(view.PassSerial))
                view.PassSerial = "****";

            if (!string.IsNullOrEmpty(view.PassNum))
                view.PassNum = "******";
        }
    }
}
