﻿using System;
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
    }
        public Road(int l, int w)
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