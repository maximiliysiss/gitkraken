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
        /// Сериализация объекта Soldier
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>List</returns>
        public override List<Soldier> Serialize(SqlDataReader reader)
        {
            List<Soldier> soldiers = new List<Soldier>();
            while (reader.Read())
            {
                try
                {
                    if ((TypeEntity)reader["TypeEntity ID"] == TypeEntity.Soldier)
                    {
                        if (Convert.ToInt32(reader["X"]) < 0 || Convert.ToInt32(reader["Y"]) < 0 || Convert.ToInt32(reader["Z"]) < 0)
                            throw new ArgumentException("Incorrect position for this universe (only > 0) (SoldierDAO.Serialize)");
                        if (Convert.ToInt32(reader["scalyar"]) < 0)
                            throw new ArgumentException("Incorrect scalyar for this universe (only > 0) (SoldierDAO.Serialize)");
                        if (DBNull.Value == reader["health"])
                            throw new NotSpecifiedException("Health is not Specified (SoldierDAO.Serialize)");
                        int x = Convert.ToInt32(reader["X"]);
                        int y = Convert.ToInt32(reader["Y"]);
                        int z = Convert.ToInt32(reader["Z"]);
                        Tuple<int, int> vector = new Tuple<int, int>(Convert.ToInt32(reader["vector.item1"]), Convert.ToInt32(reader["vector.item2"]));
                        Quanternion quanterion = new Quanternion(Convert.ToInt32(reader["scalyar"]), vector);
                        int health = Convert.ToInt32(reader["health"]);
                        soldiers.Add(new Soldier(x, y, z, quanterion, health));
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
            return soldiers;
        }
    }
}
