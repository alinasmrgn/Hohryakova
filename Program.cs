using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
{
    static void Main(string[] args)
    {
            int i;

            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("Введите колличество транспорта");
            i = Convert.ToInt32(Console.ReadLine());
            if (i > 0)
            {
                int j = 1;
                while (i != 0)
                {
                    int tmp;

                    Console.WriteLine($"Выберите тип для транспорта №{j} (1 - машина, 2 - самолет)");
                    tmp = Convert.ToInt32(Console.ReadLine());
                    if (tmp == 1)
                    {
                        Transport car = new Transport(new PassengerCarFactory());
                        car.Start();
                        car.FuelKind();
                    }
                    else if (tmp == 2)
                    {
                        Transport plane = new Transport(new PassengerPlaneFactory());
                        plane.Start();
                        plane.FuelKind();
                    }
                   
                    i--;
                    j++;
                }
            }
            Fighter fight = new Fighter();
            fight.Launch("Убийца");
            Console.WriteLine(fight.Killer.Name);

            // у нас не получится изменить, так как объект уже создан    
            fight.Killer = Killer.getInstance("Ангел");
            Console.WriteLine(fight.Killer.Name);

            PassCarFactory carFactory = new PassCarFactory();
            PassCarBuilder builder = new DiezelSedanBuilder();
            PassCar Audi = carFactory.Build(builder);
            Console.WriteLine(Audi.ToString());

            builder = new PetrolMinivanBuilder();
            PassCar Suzuki = carFactory.Build(builder);
            Console.WriteLine(Suzuki.ToString());

            IPath road = new Road(100, 10);
            IPath clonedRoad = road.Clone();
            road.GetInfo();
            clonedRoad.GetInfo();
            IPath air = new AirPath(1000, "Туман");
            IPath clonedSea = air.Clone();
            air.GetInfo();
            clonedSea.GetInfo();

            Console.Read();

        }
    }

}
