using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Класс Игрока
    /// </summary>
    class Player : Actor, IPlayerController
    {
        /// <summary>
        /// Default Constractor
        /// </summary>
        public Player() { }

        /// <summary>
        /// Свойство живости игрока
        /// </summary>
        public bool IsDeath { get; set; }

        /// <summary>
        /// Конструктор с аргументами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        public Player(int x, int y, int z, Quanterion Rotate) : base(x, y, z, Rotate, TypeEntity.Player)
        {
            IsDeath = false;
        }

        /// <summary>
        /// Перегрузка метода получения информации
        /// </summary>
        /// <returns>Aboyut player</returns>
        public override string GetInformation()
        {
            return $"This is player - {PositionInformation()} IsDeath = {IsDeath}";
        }

        /// <summary>
        /// Метод действие
        /// </summary>
        public void Action() { }

        /// <summary>
        /// Метод смерти
        /// </summary>
        public void Death() { }

        /// <summary>
        /// Метод взаимодействие
        /// </summary>
        public void Interact() { }

        /// <summary>
        /// Метод прыжка
        /// </summary>
        public void Jump() { }

        /// <summary>
        /// Метод движения
        /// </summary>
        public void Move() { }

        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="db">База данных</param>
        /// <param name="index">Индекс строки в базе данных</param>
        public override void Serialize(Reader db, int index)
        {
            if (db.GetAllRecords()[index].TypeEntity != (int)TypeEntity.Player)
                throw new ArgumentException($"Incorrect Type Of Entity (Player.Serialize|Index = {index})");
            this.IsDeath = db.GetAllRecords()[index].IsDeath.HasValue ? true : false;
            try
            {
                base.Serialize(db, index);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}(Player.Serialize|Index = {index})");
            }
        }
    }
}
