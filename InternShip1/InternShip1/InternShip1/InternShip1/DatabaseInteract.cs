using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Шаблонный класс подключения к базе данных
    /// </summary>
    /// <typeparam name="T">Тип параметра</typeparam>
    class DatabaseInteract<T> where T : class, IIntegerKey, new()
    {

        /// <summary>
        /// Получить Id роли для параметра T
        /// </summary>
        /// <param name="sqlConnection">Подключение</param>
        /// <returns>ID</returns>
        private int? GetRole(SqlConnection sqlConnection)
        {
            using (var sqlCmd = new SqlCommand($"select * from Type where Name='{typeof(T).Name}'", sqlConnection))
            {
                using (var reader = sqlCmd.ExecuteReader())
                {
                    reader.Read();
                    return Convert.ToInt32(reader["Id"]);
                }
            }
        }

        /// <summary>
        /// Выгрузка списка данных
        /// </summary>
        /// <param name="sql">Connection String</param>
        /// <returns>Лист данных</returns>
        public List<T> Load(string sql)
        {
            try
            {
                List<T> list = new List<T>(); ;
                using (var conn = new SqlConnection(sql))
                {
                    conn.Open();
                    using (var command = new SqlCommand("select * from AllInformation", conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int? type = GetRole(conn);
                            if (!type.HasValue)
                                throw new ArgumentException("Incorrect Type");
                            while (reader.Read())
                            {
                                if (Convert.ToInt32(reader["TypeOfEntity"]) == type)
                                {
                                    T tmp = Serialize(reader);
                                    if (tmp != null)
                                        list.Add(tmp);
                                }
                            }
                        }
                    }
                }
                return list;
            }
            catch (NotSpecifiedException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Сериализатор данных
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>Экземпляр объекта</returns>
        public virtual T Serialize(SqlDataReader reader)
        {
            T elem = new T();

            foreach (var prop in elem.GetType().GetProperties())
            {
                try
                {
                    if (prop.Name == "Rotate")
                        foreach (var qprop in elem.Rotate.GetType().GetProperties())
                            qprop.SetValue(elem.Rotate, reader[qprop.Name]);
                    else
                        prop.SetValue(elem, reader[prop.Name]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message} Property is {prop.Name} in Serialize in object type '{typeof(T).Name}'");
                    return null;
                }
            }

            return elem;

        }

    }
}
