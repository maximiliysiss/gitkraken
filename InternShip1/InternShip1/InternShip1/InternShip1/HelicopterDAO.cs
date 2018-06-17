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
        /// Перегруженный метод сериализации объекта
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>List</returns>
        public override List<Helicopter> Serialize(SqlDataReader reader)
        {
            List<Helicopter> helicopters = new List<Helicopter>();
            while (reader.Read())
            {
                try
                {
                    if ((TypeEntity)reader["TypeEntity ID"] == TypeEntity.Helicopter)
                    {
                        if (Convert.ToInt32(reader["X"]) < 0 || Convert.ToInt32(reader["Y"]) < 0 || Convert.ToInt32(reader["Z"]) < 0)
                            throw new ArgumentException("Incorrect position for this universe (only > 0) (HelicopterDAO.Serialize)");
                        if (Convert.ToInt32(reader["scalyar"]) < 0)
                            throw new ArgumentException("Incorrect scalyar for this universe (only > 0) (HelicopterDAO.Serialize)");
                        if (DBNull.Value == reader["weight"])
                            throw new NotSpecifiedException("Weight is not Specified (HelicopterDAO.Serialize)");
                        int x = Convert.ToInt32(reader["X"]);
                        int y = Convert.ToInt32(reader["Y"]);
                        int z = Convert.ToInt32(reader["Z"]);
                        Tuple<int, int> vector = new Tuple<int, int>(Convert.ToInt32(reader["vector.item1"]), Convert.ToInt32(reader["vector.item2"]));
                        Quanternion quanterion = new Quanternion(Convert.ToInt32(reader["scalyar"]), vector);
                        int weight = Convert.ToInt32(reader["weight"]);
                        helicopters.Add(new Helicopter(x, y, z, quanterion, weight));
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
            return helicopters;
        }
    }
}
