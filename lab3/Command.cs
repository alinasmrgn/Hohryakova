using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public interface ICommand
    {
        void Execute();
    }

    public class Go
    {
        public void Operation(char @operator)
        {
            switch (@operator)
            {
                case 'w':
                    Console.WriteLine("Герой пошел вперед!");
                    break;
                case 's':
                    Console.WriteLine("Герой пошел назад!");
                    break;

            }
        }
    }
    public class GoCommand : ICommand
    {
        private readonly Go _go;
        private readonly char _operator;        public GoCommand(Go go, char @operator)
        {
            _go = go;
            _operator = @operator;

        }
        public void Execute()
        {
            _go.Operation(_operator);
        }
    }
   
   
    public class Hit
    {
        public void Operation(char @operator)
        {
            switch (@operator)
            {
                case 'k':
                    Console.WriteLine("Герой бьет левой рукой!");
                    break;
                case 'l':
                    Console.WriteLine("Герой бьет правой рукой!");
                    break;

            }
        }
    }
    public class HitCommand : ICommand
    {
        private readonly Hit _hit;
        private readonly char _operator;        public HitCommand(Hit hit, char @operator)
        {
            _hit = hit;
            _operator = @operator;

        }
        public void Execute()
        {
            _hit.Operation(_operator);
        }
    }
    public class Player
    {
        private readonly Go _go = new Go();
        private readonly Hit _hit = new Hit();
        public void Move(char @operator)
        {
            var command = new GoCommand(_go, @operator);
            command.Execute();
        }
        public void Strike(char @operator)
        {
            var command = new HitCommand(_hit, @operator);
            command.Execute();
        }
       /*представляет объект, поведение которого должно динамически изменяться в соответствии с состоянием.
        Выполнение же конкретных действий делегируется объекту состояния*/
        public AbstractState State = State0.Instance;
        public void HandleMissed()
        {
            State.HandleMissed(this);
        }
        public void HandleBlocked()
        {
            State.HandleBlocked(this);
        }
        //// Originator---------------------------------------------------------
        private int Equipment = 10;
        private int Level = 1;
        public void Enchancment()
        {
            if (Equipment > 0)
            {
                Equipment--;
                Level++;
                Console.WriteLine("Снаряжение улучшено до уровня {0}, осталось наборов для улучшения {1} ",Level, Equipment);
            }
            else
            {
                Console.WriteLine("Наборы для улучшения закончились");
            }

        }

        public PlayerMemento SaveState()
        {
            Console.WriteLine("Сохранение игры. Кол-во наборов улучшения {0}, уровень снаряжения {1}", Equipment, Level);
            return new PlayerMemento(Equipment, Level);
        }

        public void RestoreState(PlayerMemento memento)
        {
            this.Equipment = memento.enchKit;
            this.Level = memento.equipLevel;
            Console.WriteLine("Восстановление игры. Кол-во наборов улучшения {0}, уровень снаряжения {1}",Equipment, Level);
        }
    }
}


