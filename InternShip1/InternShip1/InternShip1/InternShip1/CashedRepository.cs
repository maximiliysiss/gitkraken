using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Загрузка данных с кэшированием
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    abstract class CashedRepository<T> : DatabaseInteract<T> where T : class, IIntegerKey, new()
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Словарь для хранения данных
        /// </summary>
        private Dictionary<int, T> cashedElements = new Dictionary<int, T>();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sql">Строка подключения</param>
        public CashedRepository(string sql)
        {
            connectionString = sql;
        }

        /// <summary>
        /// Загрузка данных по лямбда выражению
        /// </summary>
        /// <param name="func">Лямбда</param>
        /// <returns>Лист</returns>
        public List<T> LoadFromCacheByLinq(Func<T, bool> func)
        {
            if (cashedElements.Count == 0)
                cashedElements = Load(connectionString).ToDictionary(a => a.Id, a => a);
            return cashedElements.Where(x => func(x.Value)).Select(x => x.Value).ToList();
        }

        /// <summary>
        /// Загрузка по Id
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Сущность</returns>
        public T LoadById(int index)
        {
            if (cashedElements.TryGetValue(index, out T val))
                return val;
            else
            {
                var newData = Load(connectionString);
                cashedElements = newData.ToDictionary(a => a.Id, a => a);
                if (cashedElements.TryGetValue(index, out T val2))
                    return val2;
                else
                    throw new ArgumentOutOfRangeException("Not found Element");
            }
        }
    }
}
