using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            char i = '0';
            Console.WriteLine("Добро пожаловать в игру. Для выхода нажмите  - n");

            do
            {
                i = Convert.ToChar(Console.ReadLine());
                if (i == 'w' || i == 's')
                {
                    player.Move(i);
                }
                else if (i == 'k' || i == 'l')
                {
                   player.Strike(i);
                }
                else
                {
                    Console.WriteLine("Введена неверная команда");
                }

            } while (i != 'n');

            
            player.HandleMissed();
            player.HandleMissed();
            player.HandleBlocked();
            player.HandleMissed();
            player.HandleBlocked();
            player.HandleBlocked();

            player.Enchancment();
            GameHistory game = new GameHistory();
            game.History.Push(player.SaveState());
            player.Enchancment();
            player.RestoreState(game.History.Pop());
            player.Enchancment();
        }
    }
}
