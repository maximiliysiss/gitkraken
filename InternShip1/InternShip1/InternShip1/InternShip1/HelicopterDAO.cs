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
    class HelicopterDAO : CashedRepository<Helicopter>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sql">Строка подключения</param>
        public HelicopterDAO(string sql) : base(sql)
        {
        }

        /// <summary>
        /// Перегруженный метод сериализации объекта
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>List</returns>
        public override Helicopter Serialize(SqlDataReader reader)
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
                    int id = Convert.ToInt32(reader["Id"]);
                    return new Helicopter(x, y, z, quanterion, weight) { Id = id };
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
            return null;
        }
    }
}
