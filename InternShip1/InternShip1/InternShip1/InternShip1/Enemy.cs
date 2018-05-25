using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс Врага
    /// </summary>
    abstract class Enemy : Actor
    {
        /// <summary>
        /// Default Constractor
        /// </summary>
        public Enemy() { levelAgressive = 0; }

        /// <summary>
        /// Конструктор с аргументами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        /// <param name="levelAgressive">Level of agressive</param>
        public Enemy(int x, int y, int z, Quanterion Rotate, short levelAgressive, TypeEntity TypeEntity) : base(x, y, z, Rotate, TypeEntity)
        {
            this.levelAgressive = levelAgressive;
        }

        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="db">База данных</param>
        /// <param name="index">Индекс строки в базе данных</param>
        public override void Serialize(Reader db, int index)
        {
            if (!db.GetAllRecords()[index].levelAgressive.HasValue)
                throw new ArgumentNullException($"levelAgressive is null (Enemy.Serialize|Index = {index})");
            this.levelAgressive = db.GetAllRecords()[index].levelAgressive.Value;
            try
            {
                base.Serialize(db, index);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}(Enemy.Serialize|Index = {index})");
            }
        }

        /// <summary>
        /// Уровень агрессии
        /// </summary>
        protected int levelAgressive;

        /// <summary>
        /// Получить дополнительную информацию о враге
        /// </summary>
        /// <returns>Information of object</returns>
        public abstract string GetInformationAboutEnemy();

        /// <summary>
        /// Перегрузка метода получения информации
        /// </summary>
        /// <returns>All information about object</returns>
        public override string GetInformation()
        {
            return $"This is enemy - {GetInformationAboutEnemy()} - {PositionInformation()}; Level of agressive is {levelAgressive}";
        }
    }
}
