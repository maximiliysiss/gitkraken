using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс Actor
    /// </summary>
    abstract class Actor
    {
        /// <summary>
        /// Поворот
        /// </summary>
        public Quanterion Rotate { get; set; }

        /// <summary>
        /// Позиции
        /// </summary>
        protected int x, y, z;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Actor()
        {
            this.x = this.y = this.z = 0;
            this.Rotate = new Quanterion();
        }

        /// <summary>
        /// Получение информации о позиционировании
        /// </summary>
        /// <returns>Position Information</returns>
        protected String PositionInformation()
        {
            return $"position({x},{y},{z}) quanterion = {Rotate.ToString()}";
        }


        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate"></param>
        public Actor(int x, int y, int z, Quanterion Rotate)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.Rotate = Rotate;
        }

        /// <summary>
        /// Виртуальный метод получения полной информации об Actor
        /// </summary>
        /// <returns>You get this string, if you don't override this method</returns>
        public virtual String GetInformation() { return "You get this string, if you don't override this method"; }
    }
}
