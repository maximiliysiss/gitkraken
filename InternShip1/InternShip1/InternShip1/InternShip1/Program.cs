using System;
using System.Collections.Generic;
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
            Reader reader = new Reader();
            List<Actor> actors = new List<Actor>();
            for (int i = 0; i < reader.GetAllRecords().Count; i++)
            {
                try
                {
                    Actor actor = null;
                    switch ((TypeEntity)reader.GetAllRecords()[i].TypeEntity)
                    {
                        case TypeEntity.Helicopter:
                            actor = new Helicopter();
                            break;
                        case TypeEntity.Player:
                            actor = new Player();
                            break;
                        case TypeEntity.Soldier:
                            actor = new Soldier();
                            break;
                        default:
                            throw new ArgumentException($"Exception - Unknown TypeEntity (Program|Index = {i})");
                    }
                    actor.Serialize(reader, i);
                    actors.Add(actor);
                    Console.WriteLine(actor.GetInformation());
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine($"Exception is ({ex.Message})");
                }
            }
        }
    }
}
