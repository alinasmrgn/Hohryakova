using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    abstract class PCar
    {
        public PCar(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class BelarusianPCar : PCar
    {
        public BelarusianPCar() : base("Белорусская машина")
        { }
        public override int GetCost()
        {
            return 10000;
        }
    }
    class ChinesePCar : PCar
    {
        public ChinesePCar()
            : base("Китайская машина")
        { }
        public override int GetCost()
        {
            return 8000;
        }
    }

    abstract class PCarDecorator : PCar
    {
        protected PCar pcar;
        public PCarDecorator(string n, PCar pcar) : base(n)
        {
            this.pcar = pcar;
        }
    }

    class FiveSitPCar : PCarDecorator
    {
        public FiveSitPCar(PCar p)
            : base(p.Name + ", пятиместная", p)
        { }

        public override int GetCost()
        {
            return pcar.GetCost() + 500;
        }
    }

    class SixSitPCar : PCarDecorator
    {
        public SixSitPCar(PCar p)
            : base(p.Name + ", шестиместная ", p)
        { }

        public override int GetCost()
        {
            return pcar.GetCost() + 600;
        }
    }
}
