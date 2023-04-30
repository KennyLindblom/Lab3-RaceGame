using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame
{
     public class Cars
     {
        public string Name { get; set; }
        public int Speed { get; set; }
        public decimal Distance { get; set; }
        public bool RanOutOfGas { get; set; }
        public bool GotFlatTire { get; set; }
        public bool HitBird { get; set; }
        public bool EngineTrouble { get; set; }


        public Cars(string name, int speed)
        {
            this.Name = name;
            this.Speed = speed;
            this.Distance = 0;
            this.RanOutOfGas = false;
            this.GotFlatTire = false;
            this.HitBird = false;
            this.EngineTrouble = false;

        }
     }

   


 
   
}
