using System;
using System.Threading;



namespace NuniTeam
{
    class Program
    { 
        static void Main(string[] args)
        {
           
            Thread ThreadSpawn = new Thread(Car.Spawn);
            ThreadSpawn.Start();
            
            
            while(Car.IsAlive)
            {
                Game.Update();
                   
            }
       
        }
    }
    public static class Game
    {
        static Car car = new Car();
        public static void Update(){
            
            car.Move();
        }
    }


    public class Car    
    {

        private static int _index = 0;
        private static int _health = 100;
        public int Health// Для надписи здоровья
        {
            get { return _health; }
        }
        private static int _dollar = 0;
        public int Dollar//для надписи монет
        {
            get { return _dollar; }
        }
        public static bool IsAlive = true;
        static int RandomNumber;//будущий рандом
        static Random rnd = new Random();//рандом
       
        static public int IndexRightRoadItem = 2;
        static public int IndexLeftRoadItem = 6;
        

        public void Move()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if((key.Key == ConsoleKey.D) )
            {
                Road.FullEmptyRoad[8,6] = Road.Car;
                Road.FullEmptyRoad[8,2] = Road.Empty;
                Road.ClearAndWriteEmpty();
            } 
            if((key.Key == ConsoleKey.A) )
            {
                Road.FullEmptyRoad[8,2] = Road.Car;
                Road.FullEmptyRoad[8,6] = Road.Empty;
                Road.ClearAndWriteEmpty();
            }
            if(key.Key == ConsoleKey.Escape)
            {
                Death();
            }
        }
        public static void ApplyDamage(int DamageValue)
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
            Console.Clear();
            Console.WriteLine($"GameOver\nтвой счет : {_dollar}");
        }

        public static void Spawn()
        {  
            for(int i = 0 ; i < 10 ; i++)
            {
                RandomNumber = rnd.Next(1,3);// выбор спавна предмета 50\50
                if(RandomNumber == 1)
                {
                    Road.SpawnItem = Road.DollarOnRoad;
                }
                else
                {
                    Road.SpawnItem = Road.SpikeOnRoad;
                }
                
                RandomNumber = rnd.Next(1,3);// выбор дороги 50\50
                if(RandomNumber == 1)
                {
                    for(;_index < 8;_index++)
                    {
                        Road.FullEmptyRoad[_index, IndexLeftRoadItem] = Road.Empty;
                        if((Road.FullEmptyRoad[_index + 1, IndexLeftRoadItem] == Road.Car))
                        {
                            if(Road.SpawnItem == Road.DollarOnRoad)
                            {
                                _dollar++;
                            }
                            else
                            {
                                ApplyDamage(20);
                            }
                            Road.ClearAndWriteEmpty();
                            break;
                        }
                        else
                        {
                            Road.FullEmptyRoad[_index + 1, IndexLeftRoadItem] = Road.SpawnItem;
                        }
                        Road.ClearAndWriteEmpty();
                        Thread.Sleep(500);
                    }
                    Road.FullEmptyRoad[_index, IndexLeftRoadItem] = Road.Empty;
                    _index = 0;
                }
                else
                {
                    for(;_index < 8;_index++)
                    {
                        Road.FullEmptyRoad[_index, IndexRightRoadItem] = Road.Empty;
                        if((Road.FullEmptyRoad[_index + 1, IndexRightRoadItem] == Road.Car))
                        {
                            if(Road.SpawnItem == Road.DollarOnRoad)
                            {
                                _dollar++;
                            }
                            else
                            {
                                ApplyDamage(20);
                            }
                            Road.ClearAndWriteEmpty();
                            break;
                        }
                        else
                        {
                            Road.FullEmptyRoad[_index + 1, IndexRightRoadItem] = Road.SpawnItem;
                        }
                        Road.ClearAndWriteEmpty();
                        Thread.Sleep(500);
                    }
                    Road.FullEmptyRoad[_index, IndexRightRoadItem] = Road.Empty;
                    _index = 0;   
                }
            }
            
            
        }

        public class Road
        {
            public static string Car = "█";
            public static string DollarOnRoad = "$";
            public static string SpikeOnRoad = "*";
            public static string Empty = " ";
            
            static public string SpawnItem = "";
            static Car car = new Car();

            public static string [,] FullEmptyRoad = {{" ", " ", " ", " ", " ", " ", " ", " ", "\n"},
                                                    {"|", " ", " ", " ", "|", " ", " ", " ", "|\n"},
                                                    {"|", " ", " ", " ", "|", " ", " ", " ", "|\n"},
                                                    {"|", " ", " ", " ", "|", " ", " ", " ", "|\n"},
                                                    {"|", " ", " ", " ", "|", " ", " ", " ", "|\n"},
                                                    {"|", " ", " ", " ", "|", " ", " ", " ", "|\n"},
                                                    {"|", " ", " ", " ", "|", " ", " ", " ", "|\n"},
                                                    {"|", " ", " ", " ", "|", " ", " ", " ", "|\n"},
                                                    {"|", " ", "█", " ", "|", " ", " ", " ", "|\n"}};
            public static void WriteEmptyRoad()
            {
                foreach(string i in FullEmptyRoad)
                {
                    Console.Write(i);
                }
                Console.WriteLine($"Сколько монет: {car.Dollar}"); //сколько монет
                Console.WriteLine($"Сколько здоровья : {car.Health}"); //сколько здоровья
            }

            public static void ClearAndWriteEmpty()
            {
                Console.Clear();
                Road.WriteEmptyRoad();  
            }
        }
      
    }
   

  
}
