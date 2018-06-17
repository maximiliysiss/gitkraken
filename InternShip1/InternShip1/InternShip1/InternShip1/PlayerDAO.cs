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
        /// Сериализация объекта Player
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>List</returns>
        public override List<Player> Serialize(SqlDataReader reader)
        {
            List<Player> players = new List<Player>();
            while (reader.Read())
            {
                try
                {
                    if ((TypeEntity)reader["TypeEntity ID"] == TypeEntity.Player)
                    {
                        if (Convert.ToInt32(reader["X"]) < 0 || Convert.ToInt32(reader["Y"]) < 0 || Convert.ToInt32(reader["Z"]) < 0)
                            throw new ArgumentException("Incorrect position for this universe (only > 0) (PlayerDAO.Serialize)");
                        if (Convert.ToInt32(reader["scalyar"]) < 0)
                            throw new ArgumentException("Incorrect scalyar for this universe (only > 0) (PlayerDAO.Serialize)");
                        int x = Convert.ToInt32(reader["X"]);
                        int y = Convert.ToInt32(reader["Y"]);
                        int z = Convert.ToInt32(reader["Z"]);
                        Tuple<int, int> vector = new Tuple<int, int>(Convert.ToInt32(reader["vector.item1"]), Convert.ToInt32(reader["vector.item2"]));
                        Quanternion quanterion = new Quanternion(Convert.ToInt32(reader["scalyar"]), vector);
                        bool isDeath = Convert.ToBoolean(reader["IsDeath"]);
                        players.Add(new Player(x, y, z, quanterion, isDeath));
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NotSpecifiedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return players;
        }
    }
}
