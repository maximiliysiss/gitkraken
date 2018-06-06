using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс получение Вертолетов
    /// </summary>
    class HelicopterDAO : DatabaseInteract<Helicopter>
    {
        /// <summary>
        /// Конструктор от строки подключения
        /// </summary>
        /// <param name="connection"></param>
        public HelicopterDAO(string connection) : base(connection) { }

        /// <summary>
        /// Перегруженный метод сериализации объекта
        /// </summary>
        /// <param name="reader">Ридер</param>
        /// <returns>Helicopter</returns>
        public override Helicopter Serialize(SqlDataReader reader)
        {
            if (types.Where(x => x.Id == Convert.ToInt32(reader["TypeEntity ID"])).First().Name != "Helicopter")
                return null;
            if (Convert.ToInt32(reader["X"]) < 0 || Convert.ToInt32(reader["Y"]) < 0 || Convert.ToInt32(reader["Z"]) < 0)
                throw new ArgumentException("Incorrect position for this universe (only > 0) (HelicopterDAO.Serialize)");
            if (Convert.ToInt32(reader["scalyar"]) < 0)
                throw new ArgumentException("Incorrect scalyar for this universe (only > 0) (HelicopterDAO.Serialize)");
            if (reader.IsDBNull(9))
                throw new ArgumentNullException($"Weight (HelicopterDAO.Serialize)");
            Helicopter helicopter = new Helicopter(Convert.ToInt32(reader["X"]), Convert.ToInt32(reader["Y"]),
                Convert.ToInt32(reader["Z"]), new Quanterion(Convert.ToInt32(reader["scalyar"]),
                new Tuple<int, int>(Convert.ToInt32(reader["vector.item1"]), Convert.ToInt32(reader["vector.item2"]))),
            Convert.ToInt32(reader["weight"]));
            return helicopter;
        }
    }
}
