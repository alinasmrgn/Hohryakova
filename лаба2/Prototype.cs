using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
  

    class Driver
    {
        public void Travel(IPath path)
        {
            path.Drive();
        }
    }
    interface AirPath
    {
        void Fly();
    }

    interface IPath
    {

        void Drive();
    }
    class Helicopter : AirPath
    {
        public void Fly()
        {
            Console.WriteLine($"Вертолет летит ! ");
        }
    }
    class Auto : IPath
    {
        int speed;

        public Auto(int s)
        {
            speed = s;

        }


        public void Drive()
        {
            Console.WriteLine($"Авто со скоростью {speed} ");
        }

    }
    // Адаптер от Camel к ITransport
    class HelicopterToTransportAdapter : IPath
    {
        Helicopter helicopter;
        public HelicopterToTransportAdapter(Helicopter h)
        {
            helicopter = h;
        }

        public void Drive()
        {
            helicopter.Fly();
        }
    }
  

}
