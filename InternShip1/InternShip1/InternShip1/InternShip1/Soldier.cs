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
        /// Здоровье
        /// </summary>
        private int health = 100;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        public Soldier(int x, int y, int z, Quanterion Rotate) : base(x, y, z, Rotate, 10, TypeEntity.Soldier)
        {
        }

        /// <summary>
        /// Перегрузка метода дополнительной информации о враге
        /// </summary>
        /// <returns>I'm soldier</returns>
        public override string GetInformationAboutEnemy()
        {
            return $"I'm soldier and hp = {this.health}";
        }

        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="db">База Данных</param>
        /// <param name="index">Индекс записи в базе данных</param>
        public override void Serialize(Reader db, int index)
        {
            if (!db.GetAllRecords()[index].health.HasValue)
                throw new ArgumentNullException($"Health is null (Soldier.Serialize|Index = {index})");
            this.health = db.GetAllRecords()[index].health.Value;
            try
            {
                base.Serialize(db, index);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}(Soldier.Serialize|Index = {index})");
            }
        }
    }
}
