using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс для работы с типами в БД
    /// </summary>
    class TypeDAO : DatabaseInteract<Type>
    {
        /// <summary>
        /// Конструктор от строки соединения
        /// </summary>
        /// <param name="connection">Строка соединиения</param>
        public TypeDAO(string connection) { ConnectionString = connection; }

        /// <summary>
        /// Перегрузка сериализации объекта Type
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>Type</returns>
        public override Type Serialize(SqlDataReader reader)
        {
            Type type = new Type() { Id = Convert.ToInt32(reader["Id"]), Name = reader["Name"].ToString() };
            return type;
        }
    }
}
