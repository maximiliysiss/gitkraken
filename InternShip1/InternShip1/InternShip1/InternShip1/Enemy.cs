using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        /// <param name="db">Reader</param>
        public override void Serialize(SqlDataReader db)
        {
            if (db.IsDBNull(8))
                throw new ArgumentNullException($"levelAgressive is null (Enemy.Serialize)");
            this.levelAgressive = ((int?)db["levelAgressive"]).Value;
            try
            {
                base.Serialize(db);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}(Enemy.Serialize)");
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
