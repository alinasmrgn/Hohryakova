using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
        public abstract class AbstractState
        {
            public abstract void HandleMissed(Player player);
            public abstract void HandleBlocked(Player player);
        }
      
        public class State0 : AbstractState
        {
            public static readonly State0 Instance = new State0();
            public override void HandleMissed(Player player)
            {
                Console.WriteLine("Удар пропущен!");
                player.State = State1.Instance;
            }

            public override void HandleBlocked(Player player)
            {
                Console.WriteLine("Удар противника заблокирован. Игрок нанес удар!");
                player.State = State3.Instance;
            }
        }
        public class State1 : AbstractState
        {
            public static readonly State1 Instance = new State1();
            public override void HandleMissed(Player player)
            {
                Console.WriteLine("Удар пропущен. У игрока потемнело в глазах");
                player.State = State2.Instance;
            }

            public override void HandleBlocked(Player player)
            {
                Console.WriteLine("Удар противника заблокирован. Игрок нанес удар!");
                player.State = State3.Instance;
            }
        }

        public class State2 : AbstractState
        {
            public static readonly State2 Instance = new State2();
            public override void HandleMissed(Player player)
            {
                Console.WriteLine("Удар пропущен. Игрок пошатнулся");
                player.State = State2.Instance;
            }
            public override void HandleBlocked(Player player)
            {
                Console.WriteLine("Удар противника заблокирован. Игрок нанес удар!");
                player.State = State3.Instance;
            }
        }

        public class State3 : AbstractState
        {
            public static readonly State3 Instance = new State3();

            public override void HandleMissed(Player player)
            {
                Console.WriteLine("Удар пропущен");
                player.State = State0.Instance;
            }

            public override void HandleBlocked(Player player)
            {
                Console.WriteLine("Удар противника заблокирован. Игрок нанес удар. Противник побежден!");
                player.State = State0.Instance;
            }
        }
  
}
