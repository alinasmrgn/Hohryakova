using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
   
    class Fighter
    {
        public Killer Killer { get; set; }
        public void Launch(string name)
        {
            Killer = Killer.getInstance(name);
        }
    }
    class Killer
    {
        private static Killer instance;

        public string Name { get; private set; }

        protected Killer(string name)
        {
            this.Name = name;
        }

        public static Killer getInstance(string name)
        {
            if (instance == null)
                instance = new Killer(name);
            return instance;
        }
    }

}
