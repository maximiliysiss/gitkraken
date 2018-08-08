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
    class Quanternion
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
        /// Составляющая вектора1
        /// </summary>
        /// 
        public int vector1 { get; set; }

        /// <summary>
        /// Составляющая вектора2
        /// </summary>
        public int vector2 { get; set; }

        /// <summary>
        /// Default Constractor
        /// </summary>
        public Quanternion()
        {
            scalyar = 1;
            vector1 = vector2 = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="scalyar">Скаляр</param>
        /// <param name="Vector">Вектор</param>
        public Quanternion(int scalyar, Tuple<int, int> Vector)
        {
            this.scalyar = scalyar;
            vector1 = Vector.Item1;
            vector2 = Vector.Item2;
        }

        /// <summary>
        /// Перегрузка метода ToString()
        /// </summary>
        /// <returns>About Quanterion</returns>
        public override string ToString()
        {
            return $"scalyar = {Scalyar} vector({vector1},{vector2})";
        }
    }
}
