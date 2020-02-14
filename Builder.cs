using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
        class Engine
        {
            public string engineType { get; set; }
        }

        class Body
        {
            public string bodyType { get; set; }
        }
        

        class PassCar
        {
            public Engine Engine { get; set; }
            public Body Body { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                if (Body != null)
                sb.Append("Тип кузова " + Body.bodyType + "\n");
                if (Engine != null)
                sb.Append("Тип двигателя " + Engine.engineType + "\n");
               
                return sb.ToString();
        }
        }
       
     
        abstract class PassCarBuilder
        {
            public PassCar PassCar { get; private set; }
            public void CreatePassCar()
            {
               PassCar = new PassCar();
            }
            public abstract void SetEngine();
            public abstract void SetBody();
            
        }
    
        class PassCarFactory
        {
        public PassCar Build(PassCarBuilder carBuilder)
        {
            carBuilder.CreatePassCar();
            carBuilder.SetEngine();
            carBuilder.SetBody();
            return carBuilder.PassCar;
        }
    }
    // строитель для 
    class PetrolMinivanBuilder : PassCarBuilder
    {
        public override void SetBody()
        {
            this.PassCar.Body = new Body { bodyType = "Minivan" };
        }
        public override void SetEngine()
        {
            this.PassCar.Engine = new Engine { engineType = "Petrol Enigine" };
        }
       
    }

    class DiezelSedanBuilder : PassCarBuilder
    {
        public override void SetBody()
        {
            this.PassCar.Body = new Body { bodyType = "Sedan" };
        }
        public override void SetEngine()
        {
            this.PassCar.Engine = new Engine { engineType = "Diezel Enigine" };
        }
      
    }
    
}
