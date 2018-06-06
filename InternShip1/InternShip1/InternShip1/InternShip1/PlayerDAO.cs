using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс получение Игроков
    /// </summary>
    class PlayerDAO : DatabaseInteract<Player>
    {
        /// <summary>
        /// Конструктор от строки подулючения
        /// </summary>
        /// <param name="connection">Строка подключения</param>
        public PlayerDAO(string connection) : base(connection) { }

        /// <summary>
        /// Сериализация объекта Player
        /// </summary>
        /// <param name="reader">Ридер</param>
        /// <returns>Player</returns>
        public override Player Serialize(SqlDataReader reader)
        {
            if (types.Where(x => x.Id == Convert.ToInt32(reader["TypeEntity ID"])).First().Name != "Player")
                return null;
            if (Convert.ToInt32(reader["X"]) < 0 || Convert.ToInt32(reader["Y"]) < 0 || Convert.ToInt32(reader["Z"]) < 0)
                throw new ArgumentException("Incorrect position for this universe (only > 0) (PlayerDAO.Serialize)");
            if (Convert.ToInt32(reader["scalyar"]) < 0)
                throw new ArgumentException("Incorrect scalyar for this universe (only > 0) (PlayerDAO.Serialize)");
            if ((int)reader["TypeEntity ID"] != (int)TypeEntity.Player)
                throw new ArgumentException($"Incorrect Type Of Entity (PlayerDAO.Serialize)");
            Player player = new Player(Convert.ToInt32(reader["X"]), Convert.ToInt32(reader["Y"]),
                Convert.ToInt32(reader["Z"]), new Quanterion(Convert.ToInt32(reader["scalyar"]),
                new Tuple<int, int>(Convert.ToInt32(reader["vector.item1"]), Convert.ToInt32(reader["vector.item2"]))),
                (Convert.ToBoolean(reader["IsDeath"])) ? true : false);
            return player;
        }
    }
}
