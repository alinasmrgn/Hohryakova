using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    //Memento
    public class PlayerMemento
    {
        public int enchKit { get; private set; }
        public int equipLevel { get; private set; }
        public PlayerMemento(int _enchKit, int _euipLevel)
        {
            this.enchKit = _enchKit;
            this.equipLevel = _euipLevel;
        }

    }
    // Caretaker
    public class GameHistory
    {
        public Stack<PlayerMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<PlayerMemento>();
        }
    }
}
