using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Типы Сущностей (Игрок, Вертолет, Солдат, Неизвестен)
    /// </summary>
    enum TypeEntity
    {
        Player = 1, Helicopter, Soldier, Unknown
    }

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
            TypeOfEntity = TypeEntity.Unknown;
        }

        /// <summary>
        /// Получение информации о позиционировании
        /// </summary>
        /// <returns>Position Information</returns>
        protected String PositionInformation()
        {
            return $"Position({x},{y},{z}) Quanterion = {Rotate.ToString()}";
        }

        /// <summary>
        /// Тип Сущности
        /// </summary>
        protected TypeEntity TypeOfEntity { get; set; }


        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate"></param>
        public Actor(int x, int y, int z, Quanterion Rotate, TypeEntity TypeEntity)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.Rotate = Rotate;
            this.TypeOfEntity = TypeEntity;
        }

        /// <summary>
        /// Виртуальный метод получения полной информации об Actor
        /// </summary>
        /// <returns>You get this string, if you don't override this method</returns>
        public virtual String GetInformation() { return "You get this string, if you don't override this method"; }
    }
}
