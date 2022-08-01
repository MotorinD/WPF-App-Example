using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task12
{
    /// <summary>
    /// Менеджер для работы с данными
    /// </summary>
    internal static class DataManager
    {

        static string jsonPath = "jsonData.txt";

        /// <summary>
        /// Сохранить список клиентов в json файл
        /// </summary>
        public static void SaveClients(List<Client> clients)
        {
            var jsonGenered = JsonConvert.SerializeObject(clients);
            File.WriteAllText(jsonPath, jsonGenered);
        }

        /// <summary>
        /// Получить список клиентов из json файла, либо если его нет возвращает тестовый заготовленный список
        /// </summary>
        public static List<Client> GetClients()
        {
            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                var clients = JsonConvert.DeserializeObject<List<Client>>(json);

                if (clients != null)
                    return clients;
            }

            return new List<Client>
            {
                new Client
                {
                    Id = 1,
                    FirstName = "Иван",
                    SecondName = "Иванов",
                    LastName = "Иванович",
                    Phone = "8-999-154-55-44",
                    PassSerial = "64 23",
                    PassNum = "898 954"
                },

                new Client
                {
                    Id = 2,
                    FirstName = "Петр",
                    SecondName = "Петров",
                    LastName = "Петрович",
                    Phone = "8-885-548-12-25",
                    PassSerial = "25 68",
                    PassNum = "784 253"
                },
                 new Client
                {
                    Id = 3,
                    FirstName = "Сергей",
                    SecondName = "Сергеев",
                    LastName = "Сергеевич",
                    Phone = "8-056-658-04-77",
                    PassSerial = "55 67",
                    PassNum = "174 534"
                }
            };
        }

        /// <summary>
        /// Сравнение представления и модели данных на предмет изменений полей. Сравнение происходит в зависимости 
        /// от доступности данных для конкретного типа пользователя (редактирование возможно только если у него FullAllow для полей)
        /// Возвращает true если изменения обнаружены. В out параметр changedFieldsString передается строковое перечисление полей которые были изменены
        /// </summary>
        public static bool IsHaveChange(IDataPermission dataPermission, Client client, ClientView view, out string changedFieldsString)
        {
            var permission = dataPermission.GetPermission();
            var changedFieldList = new List<string>();

            if (permission.FullName == PermissionEnum.FullAllow)
            {
                if (client.FirstName != view.FirstName)
                    changedFieldList.Add("Имя");

                if (client.SecondName != view.SecondName)
                    changedFieldList.Add("Фамилия");

                if (client.LastName != view.LastName)
                    changedFieldList.Add("Отчество");
            }

            if (permission.Phone == PermissionEnum.FullAllow)
            {
                if (client.Phone != view.Phone)
                    changedFieldList.Add("Телефон");
            }

            if (permission.Passport == PermissionEnum.FullAllow)
            {

                if (client.PassSerial != view.PassSerial)
                    changedFieldList.Add("Серия паспорта");

                if (client.PassNum != view.PassNum)
                    changedFieldList.Add("Номер паспорта");
            }

            if (changedFieldList.Any())
            {
                changedFieldsString = string.Join(',', changedFieldList);
                return true;
            }
            else
                changedFieldsString = string.Empty;
            return false;
        }

        public static void AddClient(Client client)
        {
            client.Id = GetNextId();
            var list = GetClients();
            list.Add(client);
            SaveClients(list);
        }

        private static int GetNextId()
        {
            var list = GetClients();
            if (list.Count == 0)
                return 1;

            var maxId = list.Select(o => o.Id).Max();

            return ++maxId;
        }

        public static void DeleteClient(int id)
        {
            var list = GetClients();

            var item = list.FirstOrDefault(o => o.Id == id);
            if (item is null)
                return;

            list.Remove(item);
            SaveClients(list);
        }
    }
}
