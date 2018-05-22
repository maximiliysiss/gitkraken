using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternShip1
{
    /// <summary>
    /// Интерфейс для игрока
    /// </summary>
    interface IPlayerController
    {
        void Move();
        void Jump();
        void Action();
        void Interact();
        void Death();
    }
}
