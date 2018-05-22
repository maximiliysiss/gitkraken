using System;
using System.Collections.Generic;
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
        /// Конструктор с аргументами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        public Helicopter(int x, int y, int z, Quanterion Rotate) : base(x, y, z, Rotate, 50)
        {
        }

        /// <summary>
        /// Перегрузка метода дополнительной информации о враге
        /// </summary>
        /// <returns>It's helicopter</returns>
        public override string GetInformationAboutEnemy()
        {
            return "It's helicopter";
        }
    }
}
