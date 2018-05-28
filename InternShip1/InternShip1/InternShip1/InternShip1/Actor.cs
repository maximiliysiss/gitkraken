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
        /// Serialize
        /// </summary>
        /// <param name="reader">Reader</param>
        public virtual void Serialize(SqlDataReader reader)
        {
            if (Convert.ToInt32(reader["X"]) < 0 || Convert.ToInt32(reader["Y"]) < 0 || Convert.ToInt32(reader["Z"]) < 0)
                throw new ArgumentException("Incorrect position for this universe (only > 0) (Actor.Serialize)");
            if (Convert.ToInt32(reader["scalyar"]) < 0)
                throw new ArgumentException("Incorrect scalyar for this universe (only > 0) (Actor.Serialize)");
            this.x = Convert.ToInt32(reader["X"]);
            this.y = Convert.ToInt32(reader["Y"]);
            this.z = Convert.ToInt32(reader["Z"]);
            this.Rotate.Scalyar = Convert.ToInt32(reader["scalyar"]);
            this.Rotate.Vector = new Tuple<int, int>(Convert.ToInt32(reader["vector.item1"]), Convert.ToInt32(reader["vector.item2"]));
        }

        /// <summary>
        /// Виртуальный метод получения полной информации об Actor
        /// </summary>
        /// <returns>You get this string, if you don't override this method</returns>
        public virtual String GetInformation() { return "You get this string, if you don't override this method"; }
    }
}
