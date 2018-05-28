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
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|\\Database.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
                try
                {
                    cn.Open();
                    SqlCommand sqlCommand = new SqlCommand("select * from AllInformation", cn);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                Actor actor = null;
                                switch ((TypeEntity)reader["TypeEntity"])
                                {
                                    case TypeEntity.Helicopter:
                                        actor = new Helicopter();
                                        actor.Serialize(reader);
                                        break;
                                    case TypeEntity.Player:
                                        actor = new Player();
                                        actor.Serialize(reader);
                                        break;
                                    case TypeEntity.Soldier:
                                        actor = new Soldier();
                                        actor.Serialize(reader);
                                        break;
                                    default:
                                        throw new ArgumentException("Unknown Type of Entity (Program)");
                                }
                                Console.WriteLine(actor.GetInformation());
                                list.Add(actor);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

}
