using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{

    abstract class Vehical
    {
        public abstract void Movement();
    }
   
    abstract class Fuel
    {
        public abstract void Consumption();
    }


    class Car : Vehical
    {
        public override void Movement()
        {
            Console.WriteLine("Машина едет");
        }
    }
   
    class Plane : Vehical
    {
        public override void Movement()
        {
            Console.WriteLine("Самолет летит");
        }
    }
    
    class PetrolFuel : Fuel
    {
        public override void Consumption()
        {
            Console.WriteLine("Используемое топливо: бензин");
        }
    }
   
    class BioFuel : Fuel
    {
        public override void Consumption()
        {
            Console.WriteLine("Используемое топливо: биотопливо");
        }
    }
    // класс абстрактной фабрики
    abstract class TransportFactory
    {
        public abstract Fuel CreateFuel();
        public abstract Vehical CreateVehical();
    }
    // Фабрика создания машины на бензине
    class PassengerCarFactory : TransportFactory
    {
        public override Fuel CreateFuel()
        {
            return new PetrolFuel();
        }

        public override Vehical CreateVehical()
        {
            return new Car();
        }
    }
    // Фабрика создания самолета на биотопливе
    class PassengerPlaneFactory : TransportFactory
    {
        public override Fuel CreateFuel()
        {
            return new BioFuel();
        }

        public override Vehical CreateVehical()
        {
            return new Plane();
        }
    }
    // клиент - сам транспорт
    class Transport
    {
        private Vehical vehical;
        private Fuel fuel;
        public Transport(TransportFactory factory)
        {
            vehical = factory.CreateVehical();
            fuel = factory.CreateFuel();
        }
        public void Start()
        {
            vehical.Movement();
        }
        public void FuelKind()
        {
            fuel.Consumption();
        }
    }
}
