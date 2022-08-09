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
        public static string [] EmptyRoad = {"|"," ", " ", " ", "|", " ", " ", " ", "|"};
        public static string [] RoadWithCarOnLeft= {"|"," ", "█", " ", "|", " ", " ", " ", "|"};
        public static string [] RoadWithCarOnRight= {"|"," ", " ", " ", "|", " ", "█", " ", "|"};
        public static string [] RoadWithDollarOnLeft = {"|"," ", "$", " ", "|", " ", " ", " ", "|"};
        public static string [] RoadWithDollarOnRight = {"|"," ", " ", " ", "|", " ", "$", " ", "|"};
        public static string [] RoadWithSpikeOnLeft = {"|"," ", "*", " ", "|", " ", " ", " ", "|"};
        public static string [] RoadWithSpikeOnRight = {"|"," ", " ", " ", "|", " ", "*", " ", "|"};

        public static string [,] FullEmptyRoad = {{"|"," ", " ", " ", "|", " ", " ", " ", "|"},{"|"," ", " ", " ", "|", " ", " ", " ", "|"},{"|"," ", " ", " ", "|", " ", " ", " ", "|"}};
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
           //создание пустой дороги
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
            if(Console.ReadKey().Key == ConsoleKey.D)
            {
                
            } 
            if(Console.ReadKey().Key == ConsoleKey.A)
            {
                
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
