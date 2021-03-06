﻿using System;
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
        public Player(int x, int y, int z, Quanternion Rotate) : base(x, y, z, Rotate, TypeEntity.Player)
        {
            IsDeath = false;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="x">Ox</param>
        /// <param name="y">Oy</param>
        /// <param name="z">Oz</param>
        /// <param name="Rotate">Rotate</param>
        /// <param name="IsDeath">IsDeath</param>
        public Player(int x, int y, int z, Quanternion Rotate, bool IsDeath) : base(x, y, z, Rotate, TypeEntity.Player)
        {
            this.IsDeath = IsDeath;
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
    }
}
