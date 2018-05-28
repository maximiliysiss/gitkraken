using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        /// <param name="db">Reader</param>
        public override void Serialize(SqlDataReader db)
        {
            if ((int)db["TypeEntity"] != (int)TypeEntity.Player)
                throw new ArgumentException($"Incorrect Type Of Entity (Player.Serialize)");
            IsDeath = (Convert.ToBoolean(db["IsDeath"])) ? true : false;
            try
            {
                base.Serialize(db);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}(Player.Serialize)");
            }
        }
    }
}
