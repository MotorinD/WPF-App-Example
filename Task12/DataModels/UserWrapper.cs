namespace Task12
{
    /// <summary>
    /// Обертка для типов пользователей 
    /// </summary>
    internal class UserWrapper
    {
        /// <summary>
        /// Тип пользователя
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Наименование для типа пользователя
        /// </summary>
        public string Name { get; set; }

        public UserWrapper(User user, string name)
        {
            this.User = user;
            this.Name = name;
        }
    }
}
