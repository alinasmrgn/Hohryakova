using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    interface IPath
    {
        IPath Clone();
        void GetInfo();
    }    class Road : IPath    {        int length;        int width;
        public Road(int l, int w)        {            length = l;            width = w;        }        public IPath Clone()        {            return new Road(this.length, this.width);        }        public void GetInfo()        {            Console.WriteLine($"Дорога с длинной {length}  и шириной {width}");        }    }    class AirPath : IPath
    {
        int length;
        string weather;

        public AirPath(int l, string w)
        {
            length = l;
            weather = w;
        }
        public IPath Clone()
        {
            return new AirPath(this.length, this.weather);
        }
        public void GetInfo()
        {
            Console.WriteLine($"Воздушный путь длиной {length}, с погодными условиями - {weather}  ");
        }
    }
}
