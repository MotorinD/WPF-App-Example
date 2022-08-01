using System;

namespace Task12
{
    internal abstract class User : IDataPermission, IShowClientViewRules, ISaveClientDataRules, ICanAddData
    {
        /// <summary>
        /// Возвращает модель данных содержащую описание доступности редактирования полей для пользователя
        /// </summary>
        public abstract DataTypesPermissionCollection GetPermission();

        /// <summary>
        /// Редактирование представления для отображения клиента в зависимости от пользователя
        /// </summary>
        /// <param name="view"></param>
        public abstract void ModifyClientView(ClientView view);

        /// <summary>
        /// Изменение модели данных клиента
        /// </summary>
        /// <param name="client"></param>
        /// <param name="view"></param>
        public virtual void ModifyClientData(Client client, ClientView view)
        {
            client.DateTimeChanged = DateTime.Now.ToString("G");
        }

        /// <summary>
        /// Пользователь имеет возсожность добавлять новые данные
        /// </summary>
        /// <returns></returns>
        public abstract bool IsCanAddData();
    }
}

