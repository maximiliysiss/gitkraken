namespace InternShip1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    /// <summary>
    /// EntityFrameWork work Представление записи
    /// </summary>
    [Table("AllInformation")]
    public partial class AllInformation
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ox
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Oy
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Oz
        /// </summary>
        public int Z { get; set; }

        /// <summary>
        /// Scalyar
        /// </summary>
        public int scalyar { get; set; }

        /// <summary>
        /// vector Ox
        /// </summary>
        [Column("vector.item1")]
        public int vector_item1 { get; set; }

        /// <summary>
        /// vector Oy
        /// </summary>
        [Column("vector.item2")]
        public int vector_item2 { get; set; }

        /// <summary>
        /// Type of Entity
        /// </summary>
        public int TypeEntity { get; set; }

        /// <summary>
        /// Level of Agressive for Enemy
        /// </summary>
        public int? levelAgressive { get; set; }

        /// <summary>
        /// Weight for Helicopter
        /// </summary>
        public int? weight { get; set; }

        /// <summary>
        /// IsDeath for Player
        /// </summary>
        public byte? IsDeath { get; set; }

        /// <summary>
        /// Health for Soldier
        /// </summary>
        public int? health { get; set; }
    }
}
