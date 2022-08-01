namespace Task12
{
    internal interface IDataPermission
    {
        /// <summary>
        /// Получить модель данных содержащуюю доступамы работы с полями
        /// </summary>
        /// <returns></returns>
        public DataTypesPermissionCollection GetPermission();
    }
}
