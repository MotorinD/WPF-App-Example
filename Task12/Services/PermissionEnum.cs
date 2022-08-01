namespace Task12
{
    /// <summary>
    /// Перечисление возможных доступов для работы с полями
    /// </summary>
    internal enum PermissionEnum
    {
        /// <summary>
        /// Полный доступ к полю
        /// </summary>
        FullAllow = 0,

        /// <summary>
        /// Только чтение, без редактирования
        /// </summary>
        ReadOnly = 1,

        /// <summary>
        /// Поле скрыто
        /// </summary>
        Hide = 2
    }
}
