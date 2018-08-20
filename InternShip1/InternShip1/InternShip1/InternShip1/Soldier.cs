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
        public int Health { get; set; } = 100;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        public Soldier(int x, int y, int z, int v1, int v2, int sc) : base(x, y, z, v1, v2, sc, 10, TypeEntity.Soldier)
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
        public Soldier(int x, int y, int z, int v1, int v2, int sc, int health) : base(x, y, z, v1, v2, sc, 10, TypeEntity.Soldier)
        {
            this.Health = health;
        }

        /// <summary>
        /// Перегрузка метода дополнительной информации о враге
        /// </summary>
        /// <returns>I'm soldier</returns>
        public override string GetInformationAboutEnemy()
        {
            return $"I'm soldier and hp = {this.Health}";
        }
    }
}
