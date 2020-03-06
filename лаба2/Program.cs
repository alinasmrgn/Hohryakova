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

            // путешественник
            Driver driver = new Driver();
            // машина
            Auto auto = new Auto(5);
            // отправляемся в путешествие
            driver.Travel(auto);
            // встретились пески, надо использовать верблюда
            Helicopter helicopter = new Helicopter();
            // используем адаптер
            IPath helicopterTransport = new HelicopterToTransportAdapter(helicopter);
            // продолжаем путь 
            driver.Travel(helicopterTransport);

            PCar pcar1 = new BelarusianPCar();
            pcar1 = new FiveSitPCar(pcar1); 
            Console.WriteLine("Название: {0}", pcar1.Name);
            Console.WriteLine("Цена: {0}", pcar1.GetCost());

            PCar pcar2 = new BelarusianPCar();
            pcar2 = new SixSitPCar(pcar2); 
            Console.WriteLine("Название: {0}", pcar2.Name);
            Console.WriteLine("Цена: {0}", pcar2.GetCost());

            PCar pcar3 = new ChinesePCar();
            pcar3 = new SixSitPCar(pcar3); 
            Console.WriteLine("Название: {0}", pcar3.Name);
            Console.WriteLine("Цена: {0}", pcar3.GetCost());

            var road = new Map { Title = "Дорога" };
            road.AddComponent(new MapComponent { Title = "Машина 1" });
            road.AddComponent(new MapComponent { Title = "Машина 2" });
            var highway = new Map { Title = "Шоссе" };
           highway.AddComponent(road);
            highway.Draw();
            var lorry = highway.Find("Машина 2");
           lorry.Draw();

            Console.Read();

        }
    }

}
