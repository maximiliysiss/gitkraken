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
    /// Интерфейс для определения ID для всех объектов
    /// </summary>
    interface IIntegerKey
    {
        int Id { get; set; }
    }

    /// <summary>
    /// Класс Actor
    /// </summary>
    class Actor : IIntegerKey
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
        public int Vector1 { get; set; }

        /// <summary>
        /// Составляющая вектора2
        /// </summary>
        public int Vector2 { get; set; }

        /// <summary>
        /// Позиции
        /// </summary>
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Actor()
        {
            this.x = this.y = this.z = 0;
            this.Vector1 = this.Vector2 = this.Scalyar = 0;
            TypeOfEntity = TypeEntity.Unknown;
        }

        /// <summary>
        /// Получение информации о позиционировании
        /// </summary>
        /// <returns>Position Information</returns>
        protected String PositionInformation()
        {
            return $"Position({x},{y},{z}) Quanterion = ({Vector1}; {Vector2}; {Scalyar})";
        }

        /// <summary>
        /// Тип Сущности
        /// </summary>
        public TypeEntity TypeOfEntity { get; set; }

        /// <summary>
        /// Реализация интерфейса
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate"></param>
        public Actor(int x, int y, int z, int v1, int v2, int sc, TypeEntity TypeEntity)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.Vector1 = v1;
            this.Vector2 = v2;
            this.scalyar = sc;
            this.TypeOfEntity = TypeEntity;
        }

        /// <summary>
        /// Виртуальный метод получения полной информации об Actor
        /// </summary>
        /// <returns>You get this string, if you don't override this method</returns>
        public virtual String GetInformation() { return "You get this string, if you don't override this method"; }
    }
}
