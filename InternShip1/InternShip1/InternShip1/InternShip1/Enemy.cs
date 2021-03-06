﻿using System;
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
        public Enemy(int x, int y, int z, Quanternion Rotate, short levelAgressive, TypeEntity TypeEntity) : base(x, y, z, Rotate, TypeEntity)
        {
            this.levelAgressive = levelAgressive;
        }

        /// <summary>
        /// Уровень агрессии
        /// </summary>
        protected int levelAgressive;

        /// <summary>
        /// Свойство для получения уровня агрессии
        /// </summary>
        public int LevelAgressive { get { return levelAgressive; } }

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
