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
        public byte IsDeath { get; set; }

        /// <summary>
        /// Конструктор с аргументами
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        public Player(int x, int y, int z, int v1, int v2, int sc) : base(x, y, z, v1, v2, sc, TypeEntity.Player)
        {
            IsDeath = 0;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        /// <param name="IsDeath">IsDeath</param>
        public Player(int x, int y, int z, int v1, int v2, int sc, byte IsDeath) : base(x, y, z, v1, v2, sc, TypeEntity.Player)
        {
            this.IsDeath = IsDeath;
        }

        /// <summary>
        /// Перегрузка метода получения информации
        /// </summary>
        /// <returns>Aboyut player</returns>
        public override string GetInformation()
        {
            return $"This is player - {PositionInformation()} IsDeath = {IsDeath == 1}";
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
    }
}
