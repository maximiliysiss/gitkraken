using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс представлющий обертку над Моделью
    /// </summary>
    class Reader
    {
        /// <summary>
        /// Эксземпляр модели базы данных
        /// </summary>
        ProjectModels db = new ProjectModels();

        /// <summary>
        /// Получить все строки о Вертолетах
        /// </summary>
        /// <returns>Лист Записей</returns>
        public List<AllInformation> GetHelicopters()
        {
            return db.AllInformations.Where(x => x.TypeEntity == (int)TypeEntity.Helicopter).ToList();
        }

        /// <summary>
        /// Получить все строки о Игроках
        /// </summary>
        /// <returns>Лист записей</returns>
        public List<AllInformation> GetPlayers()
        {
            return db.AllInformations.Where(x => x.TypeEntity == (int)TypeEntity.Player).ToList();
        }

        /// <summary>
        /// Получить все строки о Солдатах
        /// </summary>
        /// <returns>Лист записей</returns>
        public List<AllInformation> GetSoldiers()
        {
            return db.AllInformations.Where(x => x.TypeEntity == (int)TypeEntity.Soldier).ToList();
        }

        /// <summary>
        /// Получить все записи таблицы
        /// </summary>
        /// <returns>Лист записей</returns>
        public List<AllInformation> GetAllRecords()
        {
            return db.AllInformations.ToList();
        }
    }
}
