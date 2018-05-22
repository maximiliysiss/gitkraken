using System;
using System.Collections.Generic;
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
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        public Soldier(int x, int y, int z, Quanterion Rotate) : base(x, y, z, Rotate, 10)
        {
        }

        /// <summary>
        /// Перегрузка метода дополнительной информации о враге
        /// </summary>
        /// <returns>I'm soldier</returns>
        public override string GetInformationAboutEnemy()
        {
            return "I'm soldier";
        }
    }
}
