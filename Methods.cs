using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame
{
    class Methods : Cars
    {


        public Methods(string name, int speed) : base(name, speed)
        {

        }

        public static List<Cars> carList = new List<Cars>();
        public static void StartProgram()
        {
            Console.Clear();
            ColourWriteLine("------Time for Race----------");
            Console.WriteLine("Press Enter to Start the race");
            Console.ReadKey();


            Cars car1 = new Cars("Volvo", 120);
            Cars car2 = new Cars("Tesla", 120);

            carList.Add(car1);
            carList.Add(car2);

            Thread car1Thread = new Thread(() => Start(car1));
            Thread car2Thread = new Thread(() => Start(car2));
            Thread InputThread = new Thread(CheckDistance);

            Console.WriteLine($"{car1.Name} started! ");
            Console.WriteLine($"{car2.Name} started! ");
            


            car1Thread.Start();
            car2Thread.Start();

            
            InputThread.Start();



            car1Thread.Join();
            car2Thread.Join();
            InputThread.Join();




        }

        public static void ColourWriteLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            //Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ResetColor();
        }

        static void Start(object obj)
        {
            Cars car = (Cars)obj;
            int timeElapsed = 0;
            Random rand = new Random();
            bool runRace = true;
            //CheckDistance();

            //Thread animationThread = new Thread(RunAnimation);
            //animationThread.Start();






            while (car.Distance < 5000 && runRace)
            {
                
                


               
                int distanceTraveled = car.Speed / 10; 
                car.Distance += distanceTraveled;

                
                

                
                timeElapsed += 1;
                if (timeElapsed % 30 == 0)
                {
                    int eventRoll = rand.Next(1, 51); 
                    if (!car.RanOutOfGas && timeElapsed % 30 == 0 && eventRoll == 1)
                    {
                        car.RanOutOfGas = true;
                        ColourWriteLine($"{car.Name} ran out of gas and needs to refuel!");
                        CheckDistance();
                        Thread.Sleep(30000); 
                    }
                    else if (!car.GotFlatTire && eventRoll <= 3)
                    {
                        car.GotFlatTire = true;
                        ColourWriteLine($"{car.Name} got a flat tire and needs to change it!");
                        CheckDistance();
                        Thread.Sleep(20000); 
                    }
                    else if (!car.HitBird && eventRoll <= 8)
                    {
                        car.HitBird = true;
                        ColourWriteLine($"{car.Name} Oh NO! Driver hit the Vågel!");
                        CheckDistance();
                        Thread.Sleep(10000); 
                    }
                    else if (!car.EngineTrouble && eventRoll <= 18)
                    {
                        car.EngineTrouble = true;
                        ColourWriteLine($"{car.Name} is having engine trouble and is slowing down");
                        CheckDistance();
                        car.Speed -= 1; 
                    }
                    CheckDistance();
                }

                

                

                

                Thread.Sleep(100);
                

                if (car.Distance == 5000)
                {
                    runRace = false;
                    break;
                }
            }

            Console.Clear();
            //Console.WriteLine("{0} Won the race at {1} km", car.Name, car.Distance / 1000);
            PrintMessage($"{car.Name} Won the race at {car.Distance / 1000} km");
            PrintMessage("thank you for playing Lab 3 Race game");



        }


        public static void CheckDistance()
        {


            string input = Console.ReadLine();
            if (input.ToLower() == "s")
            {
                foreach (Cars item in carList)
                {
                    Console.WriteLine("{0} is at {1} km", item.Name, item.Distance / 1000);
                }



            }

        }

        public static void RunAnimation() //Inte använd än
        {
            string GoText = "------>";
            for (int i = 0; i < GoText.Length; i++)
            {
                Thread.Sleep(200);
                Console.Write(GoText[i]);
            }


        }

        static void PrintMessage(string message)
        {
            ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.DarkBlue, ConsoleColor.Cyan, ConsoleColor.DarkMagenta};
            int colorIndex = 0;
            int charIndex = 0;

            while (charIndex < message.Length)
            {
                Console.ForegroundColor = colors[colorIndex];
                Console.Write(message[charIndex]);
                colorIndex = (colorIndex + 1) % colors.Length;
                charIndex++;
                Thread.Sleep(30);
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}


    

