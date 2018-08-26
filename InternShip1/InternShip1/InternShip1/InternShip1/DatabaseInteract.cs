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
    abstract class DatabaseInteract<T> where T : class, new()
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
                                try
                                {
                                    var obj = CreateObj(reader);
                                    Serialize(reader, obj);
                                    list.Add(obj);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
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
        /// Создание дефолтного элемента
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public virtual T CreateObj(SqlDataReader reader)
        {
            return new T();
        }

        /// <summary>
        /// Сериализатор данных
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <param name="elem">Элемент для хранения</param>
        public virtual void Serialize(SqlDataReader reader, T elem)
        {
            foreach (var prop in elem.GetType().GetProperties())
            {
                try
                {
                    prop.SetValue(elem, reader[prop.Name]);
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message} Property is {prop.Name} in Serialize in object type '{typeof(T).Name}'");
                }
            }
        }

    }
}
