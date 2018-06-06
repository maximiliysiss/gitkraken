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
        private int weight;

        /// <summary>
        /// Конструктор с аргументами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        public Helicopter(int x, int y, int z, Quanterion Rotate) : base(x, y, z, Rotate, 50, TypeEntity.Helicopter)
        {
            weight = 30;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        /// <param name="weight">Weight</param>
        public Helicopter(int x, int y, int z, Quanterion Rotate, int weight) : base(x, y, z, Rotate, 50, TypeEntity.Helicopter)
        {
            this.weight = weight;
        }

        /// <summary>
        /// Перегрузка метода дополнительной информации о враге
        /// </summary>
        /// <returns>It's helicopter</returns>
        public override string GetInformationAboutEnemy()
        {
            return $"It's helicopter and it's weigth = {this.weight}";
        }
    }
}
