using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2019.Controller
{
   public static class EntryPoint
    {
        public static MonopolyGame Game = MonopolyGame.getInstance();
        public static void StartGame()
        {
            //using (Game = new MonopolyGame())
            //    Game.Run();
            Game.Run();
        }
    }
}
