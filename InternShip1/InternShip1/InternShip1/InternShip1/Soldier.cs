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
        public Soldier(int x, int y, int z, Quanternion Rotate) : base(x, y, z, Rotate, 10, TypeEntity.Soldier)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        /// <param name="health">Health</param>
        public Soldier(int x, int y, int z, Quanternion Rotate, int health) : base(x, y, z, Rotate, 10, TypeEntity.Soldier)
        {
            this.health = health;
        }

        /// <summary>
        /// Перегрузка метода дополнительной информации о враге
        /// </summary>
        /// <returns>I'm soldier</returns>
        public override string GetInformationAboutEnemy()
        {
            return $"I'm soldier and hp = {this.health}";
        }
    }
}
