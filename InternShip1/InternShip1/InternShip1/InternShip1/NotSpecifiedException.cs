using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Исключение "Не установлено"
    /// </summary>
    class NotSpecifiedException : Exception
    {
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public NotSpecifiedException() { }

        /// <summary>
        /// Конструктор от строки
        /// </summary>
        /// <param name="message">Сообщение</param>
        public NotSpecifiedException(string message) : base(message) { }

        /// <summary>
        /// Конструктор от исключения
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="inner">Исключение</param>
        public NotSpecifiedException(string message, Exception inner) : base(message, inner) { }
    }
}
