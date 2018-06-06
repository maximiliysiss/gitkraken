using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Шаблонный абстрактный класс подключения к базе данных
    /// </summary>
    /// <typeparam name="T">Тип параметра</typeparam>
    abstract class DatabaseInteract<T>
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Лист типов
        /// </summary>
        public List<Type> types;

        /// <summary>
        /// Подключение
        /// </summary>
        private SqlConnection connection;
        /// <summary>
        /// Команда
        /// </summary>
        private SqlCommand command;
        /// <summary>
        /// Ридер
        /// </summary>
        private SqlDataReader reader;



        /// <summary>
        /// Дефолтный конструктор
        /// </summary>
        public DatabaseInteract() { }

        /// <summary>
        /// Конструктор с заданием строки подключения
        /// </summary>
        /// <param name="ConnectionString">Строка подключения</param>
        public DatabaseInteract(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            types = new TypeDAO(ConnectionString).Load("select * from Type");
        }

        /// <summary>
        /// Выгрузка списка данных
        /// </summary>
        /// <param name="sql">Команда</param>
        /// <returns>Лист данных</returns>
        public List<T> Load(string sql)
        {
            try
            {
                Open();
                List<T> list = new List<T>();
                SetCommand(sql);
                var reader = GetReader();
                while (reader.Read())
                {
                    try
                    {
                        T newElement = Serialize(reader);
                        if (newElement != null)
                            list.Add(newElement);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Close();
                return list;
            }
            catch (NotSpecifiedException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Сериализатор данных
        /// </summary>
        /// <param name="reader">Ридер</param>
        /// <returns>Сформированный объект</returns>
        public abstract T Serialize(SqlDataReader reader);

        /// <summary>
        /// Открыть подключение
        /// </summary>
        public void Open()
        {
            if (ConnectionString == null)
                throw new NotSpecifiedException("Connection String not specified");
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        /// <summary>
        /// Получить сформированную команду
        /// </summary>
        /// <param name="cmd">Команда</param>
        /// <returns>Команда</returns>
        public SqlCommand SetCommand(string cmd)
        {
            if (connection == null)
                throw new NotSpecifiedException("Connection not specified");
            command = new SqlCommand(cmd, connection);
            return command;
        }

        /// <summary>
        /// Получить ридер
        /// </summary>
        /// <returns>Ридер</returns>
        public SqlDataReader GetReader()
        {
            if (command == null)
                throw new NotSpecifiedException("Command not specified");
            reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Закрыть соединение
        /// </summary>
        public void Close()
        {
            if (!reader.IsClosed)
                reader.Close();
            connection.Close();
        }
    }
}
