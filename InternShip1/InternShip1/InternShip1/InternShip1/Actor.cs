using System;
using System.Collections.Generic;
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
        Player, Helicopter, Soldier, Unknown
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
        /// Сериализация объекта на уровне Actor
        /// </summary>
        /// <param name="db">База данных</param>
        /// <param name="index">Индекс строки в глобальной базе данных</param>
        public virtual void Serialize(Reader db, int index)
        {
            AllInformation part = db.GetAllRecords()[index];
            if (part.X < 0 || part.Y < 0 || part.Z < 0)
                throw new ArgumentException($"Incorrect position for this universe (only > 0) (Actor.Serialize|Index = {index})");
            if (part.scalyar < 0)
                throw new ArgumentException($"Incorrect scalyar for this universe (only > 0) (Actor.Serialize|Index = {index})");
            this.x = part.X;
            this.y = part.Y;
            this.z = part.Z;
            this.Rotate.Scalyar = part.scalyar;
            this.Rotate.Vector = new Tuple<int, int>(part.vector_item1, part.vector_item2);
        }

        /// <summary>
        /// Виртуальный метод получения полной информации об Actor
        /// </summary>
        /// <returns>You get this string, if you don't override this method</returns>
        public virtual String GetInformation() { return "You get this string, if you don't override this method"; }
    }
}
