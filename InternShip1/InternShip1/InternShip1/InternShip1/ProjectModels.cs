namespace InternShip1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// Модель базы данных, связанная с таблицей AllInformation. Создана при помощи Code First From DataBase 
    /// </summary>
    public partial class ProjectModels : DbContext
    {
        /// <summary>
        /// Конструктор 
        /// </summary>
        public ProjectModels()
            : base("name=ProjectModels")
        {
        }

        /// <summary>
        /// Набор данных, представляющий конект к таблице 
        /// </summary>
        public virtual DbSet<AllInformation> AllInformations { get; set; }

        /// <summary>
        /// Инициализация модели
        /// </summary>
        /// <param name="modelBuilder">"Строитель" модели</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
