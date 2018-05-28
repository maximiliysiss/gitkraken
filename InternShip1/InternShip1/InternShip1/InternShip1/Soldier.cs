using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс Солдат
    /// </summary>
    class Soldier : Enemy
    {
        /// <summary>
        /// Default Constractor
        /// </summary>
        public Soldier() { }

        /// <summary>
        /// Здоровье
        /// </summary>
        private int health = 100;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        public Soldier(int x, int y, int z, Quanterion Rotate) : base(x, y, z, Rotate, 10, TypeEntity.Soldier)
        {
        }

        /// <summary>
        /// Перегрузка метода дополнительной информации о враге
        /// </summary>
        /// <returns>I'm soldier</returns>
        public override string GetInformationAboutEnemy()
        {
            return $"I'm soldier and hp = {this.health}";
        }

        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="db">Reader</param>
        public override void Serialize(SqlDataReader db)
        {
            if (db.IsDBNull(11))
                throw new ArgumentNullException($"Health is null (Soldier.Serialize)");
            this.health = Convert.ToInt32(db["health"]);
            try
            {
                base.Serialize(db);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}(Soldier.Serialize)");
            }
        }
    }
}
