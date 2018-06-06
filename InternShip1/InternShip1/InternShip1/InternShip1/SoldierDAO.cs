using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс получение Солдат
    /// </summary>
    class SoldierDAO : DatabaseInteract<Soldier>
    {
        /// <summary>
        /// Конструктор от строки подключения
        /// </summary>
        /// <param name="connection">Строка подключения</param>
        public SoldierDAO(string connection) : base(connection) { }

        /// <summary>
        /// Сериализация объекта Soldier
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public override Soldier Serialize(SqlDataReader reader)
        {
            int type = (int)reader["TypeEntity ID"];
            if (types.Where(x => x.Id == type).First().Name != "Soldier")
                return null;
            if (Convert.ToInt32(reader["X"]) < 0 || Convert.ToInt32(reader["Y"]) < 0 || Convert.ToInt32(reader["Z"]) < 0)
                throw new ArgumentException("Incorrect position for this universe (only > 0) (SoldierDAO.Serialize)");
            if (Convert.ToInt32(reader["scalyar"]) < 0)
                throw new ArgumentException("Incorrect scalyar for this universe (only > 0) (SoldierDAO.Serialize)");
            if (reader.IsDBNull(8))
                throw new ArgumentNullException($"levelAgressive is null (SoldierDAO.Serialize)");
            if (reader.IsDBNull(11))
                throw new ArgumentNullException($"Health is null (SoldierDAO.Serialize)");
            Soldier soldier = new Soldier(Convert.ToInt32(reader["X"]), Convert.ToInt32(reader["Y"]),
                Convert.ToInt32(reader["Z"]), new Quanterion(Convert.ToInt32(reader["scalyar"]),
                new Tuple<int, int>(Convert.ToInt32(reader["vector.item1"]), Convert.ToInt32(reader["vector.item2"]))),
                Convert.ToInt32(reader["health"]));
            return soldier;
        }
    }
}
