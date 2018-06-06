using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    class Program
    {
        /// <summary>
        /// Демонстрация работы написанных классов
        /// </summary>
        /// <param name="args">Аргументы для консоли</param>
        /* static void Main(string[] args)
         {
             List<Actor> actors = new List<Actor>();
             for (int i = 0; i < 5; i++)
                 actors.Add(new Soldier(0, i, 0, new Quanterion()));
             for (int i = 0; i < 2; i++)
                 actors.Add(new Helicopter(0, 0, i, new Quanterion()));
             actors.Add(new Player(0, 0, 0,  new Quanterion())); 
             foreach(Actor obj in actors) 
             {
                 Console.WriteLine(obj.GetInformation());
             }
         }*/

        static void Main(string[] args)
        {
            List<Actor> list = new List<Actor>();
            string command = "select * from AllInformation";
            string connectionString = "data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|\\Database.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            SoldierDAO soldierDAO = new SoldierDAO(connectionString);
            PlayerDAO playerDAO = new PlayerDAO(connectionString);
            HelicopterDAO helicopterDAO = new HelicopterDAO(connectionString);
            list.AddRange(soldierDAO.Load(command));
            list.AddRange(helicopterDAO.Load(command));
            list.AddRange(playerDAO.Load(command));
            foreach (Actor obj in list)
                Console.WriteLine(obj.GetInformation());
        }
    }

}
