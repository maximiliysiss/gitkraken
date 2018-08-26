using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс Вертолет
    /// </summary>
    class Helicopter : Enemy
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Helicopter() { }


        /// <summary>
        /// Вес
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Конструктор с аргументами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        public Helicopter(int x, int y, int z, int v1, int v2, int sc) : base(x, y, z, v1, v2, sc, 50, TypeEntity.Helicopter)
        {
            Weight = 30;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        /// <param name="weight">Weight</param>
        public Helicopter(int x, int y, int z, int v1, int v2, int sc, int weight) : base(x, y, z, v1, v2, sc, 50, TypeEntity.Helicopter)
        {
            this.Weight = weight;
        }

        /// <summary>
        /// Перегрузка метода дополнительной информации о враге
        /// </summary>
        /// <returns>It's helicopter</returns>
        public override string GetInformationAboutEnemy()
        {
            return $"It's helicopter and it's weigth = {this.Weight}";
        }
    }
}
