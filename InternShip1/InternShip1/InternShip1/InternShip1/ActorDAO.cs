using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс ждя таблицы AllInformation
    /// </summary>
    class ActorDAO : DatabaseInteract<Actor>
    {

        /// <summary>
        /// Перегрузка метода создания объекта
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public override Actor CreateObj(SqlDataReader reader)
        {
            switch ((TypeEntity)Convert.ToInt32(reader["TypeOfEntity"]))
            {
                case TypeEntity.Helicopter:
                    return new Helicopter();
                case TypeEntity.Player:
                    return new Player();
                case TypeEntity.Soldier:
                    return new Soldier();
            }
            return null;
        }
    }
}
