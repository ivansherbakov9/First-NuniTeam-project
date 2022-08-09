using System;

namespace NuniTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            
            
            game.Start();
            while(Car.IsAlive)
            {
                game.Update();
            }
       
        }
    }

    public class Road
    {
        public static string Car = "█";
        public static string Dollar = "$";
        public static string Spike = "*";
        public static string Empty = " ";

        public static string [,] FullEmptyRoad = {{"|"," ", " ", " ", "|", " ", " ", " ", "|\n"},{"|"," ", " ", " ", "|", " ", " ", " ", "|\n"},{"|", " ", "█", " ", "|", " ", " ", " ", "|\n"}};
        public static void WriteEmptyRoad()
        {
            foreach(string i in FullEmptyRoad)
            {
                Console.Write(i);
            }
        }
    }
       
    public class Game
    {
        Car car = new Car();
        
        public void Start()
        {
           Road.WriteEmptyRoad();
        }

        public void Update()
        {
            // создание дороги
            car.Move();
        }
    }

    public class Car    
    {
        private int _speed;
        private int _health = 100;
        private int _dollar = 0;

        public static bool IsAlive = true;

        public void Move()
        {
            if((Console.ReadKey().Key == ConsoleKey.D) )
            {
                Console.Clear();
                Road.FullEmptyRoad[2,6] = Road.Car;
                Road.FullEmptyRoad[2,2] = Road.Empty;
                Road.WriteEmptyRoad();
                
            } 
            if((Console.ReadKey().Key == ConsoleKey.A) )
            {
                Console.Clear();
                Road.FullEmptyRoad[2,2] = Road.Car;
                Road.FullEmptyRoad[2,6] = Road.Empty;
                Road.WriteEmptyRoad();
                
            }
            if(Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Death();
            }
        }

        public void ApplyDamage(int DamageValue)
        {
            _health -= DamageValue;
            if(_health <= 0)
            {
                Death();
            }
        }

        public static void Death()
        {
            Car.IsAlive = false;
        }
    }
}
