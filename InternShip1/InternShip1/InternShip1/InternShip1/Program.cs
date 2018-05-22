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
        static void Main(string[] args)
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
        }
    }
}
