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
    /// Шаблонный абстрактный класс подключения к базе данных
    /// </summary>
    /// <typeparam name="T">Тип параметра</typeparam>
    abstract class DatabaseInteract<T>
    {

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
                            while (reader.Read())
                            {
                                T elem = Serialize(reader);
                                if (elem != null)
                                    list.Add(elem);
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
        /// <returns>List</returns>
        public abstract T Serialize(SqlDataReader reader);

    }
}
