using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс Quanterion
    /// </summary>
    class Quanterion
    {
        /// <summary>
        /// Скаляр
        /// </summary>
        private int scalyar;

        /// <summary>
        /// Свойство скаляра
        /// </summary>
        public int Scalyar
        {
            get { return scalyar; }
            set { if (value < 0) throw new ArgumentException("Scalyar > 0"); scalyar = value; }
        }

        /// <summary>
        /// Вектор - автоматическое свойство
        /// </summary>
        public Tuple<int, int> Vector { get; set; }

        /// <summary>
        /// Default Constractor
        /// </summary>
        public Quanterion()
        {
            scalyar = 1;
            Vector = new Tuple<int, int>(0, 0);
        }

        /// <summary>
        /// Перегрузка метода ToString()
        /// </summary>
        /// <returns>About Quanterion</returns>
        public override string ToString()
        {
            return $"scalyar = {Scalyar} vector({Vector.Item1},{Vector.Item2})";
        }
    }
}
