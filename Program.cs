using System;
using System.Threading;//Для поточного программирования

namespace NuniTeam
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            
            Game game = new Game();
            //Car game = new Game();
            Thread Thread1 = new Thread(SpawnTime);//новый поток
            Thread1.Start();//запускаем его
            
            
            while(Car.IsAlive)
            {
                game.Update();

            }
       
        }
        public static void SpawnTime()
        {
            int spawnnum = 0;
            while (true)
            {
                if(spawnnum >= 100)
                {
                    Car.Spawn();
                    spawnnum = 0;
                }    
                else
                    spawnnum++;
            }        
        }
    }

    

    public class Road
    {
        public static string Car = "█";
        public static string Dollar = "$";
        public static string Spike = "*";
        public static string Empty = " ";

        static Car car951 = new Car();

        public static string [,] FullEmptyRoad = {{"|"," ", " ", " ", "|", " ", " ", " ", "|\n"},{"|"," ", " ", " ", "|", " ", " ", " ", "|\n"},{"|", " ", "█", " ", "|", " ", " ", " ", "|\n"}};
        public static void WriteEmptyRoad()
        {
            foreach(string i in FullEmptyRoad)
            {
                Console.Write(i);
            }
            Console.Write("Всего монет:");
            Console.WriteLine(car951.GetDollars());//сколько монет
            
            
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

        static int index = 0;


        private int _speed;
        static int _health = 100;
        static int _dollar = 0;
        //------------------
        static int num;//будущий рандом
        static int num2;
        static Random rnd = new Random();//рандом

        static public bool SpawnDollar = false;//спавнить ли сейчас доллар
        static public bool SpawnSpike = false;//спавнить ли сейчас колючку
        static public bool SpawnLeft = false;
        static public bool SpawnRight = false;

        static public int roadROL;
        static public bool CarLeft = false;//машина слево
        static public bool CarRight = true;//машина справа

        //--------------------------
        public static bool IsAlive = true;

        public void Move()
        {
            if((Console.ReadKey().Key == ConsoleKey.D) )
            {
                Console.Clear();
                Road.FullEmptyRoad[2,6] = Road.Car;
                Road.FullEmptyRoad[2,2] = Road.Empty;
                Road.WriteEmptyRoad();
                CarLeft = false;//условия где машина
                CarRight = true;//условия где машина
                //Console.Clear();
                
            } 
            if((Console.ReadKey().Key == ConsoleKey.A) )
            {
                Console.Clear();
                Road.FullEmptyRoad[2,2] = Road.Car;
                Road.FullEmptyRoad[2,6] = Road.Empty;
                Road.WriteEmptyRoad();
                CarLeft = true;//условия где машина
                CarRight = false;//условия где машина
                //Console.Clear();
                
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
        public static void Spawn()
        {
            num = rnd.Next(0, 10);//рандом
            if (num <= 2)//если 50 процентов
            {
                num2 = rnd.Next(0, 2);
                if (num2 == 0)
                {
                    SpawnLeft = true;
                    SpawnRight = false;
                }
                SpawnDollar = true;//спавним доллар
                
                SpawnSpike = false;
            }
            else
            {
                SpawnDollar = false;//иначе нет
                SpawnLeft = false;
                SpawnRight = false;
                SpawnSpike = false;
            }

            if (SpawnDollar == true)//мы спавним что то
            {
                if(SpawnLeft)
                    roadROL = 2;
                    
                else if (SpawnRight)   
                    roadROL = 6; 
        
                while(true)//цикл перемещения
                {
                    
                    
                    try
                    {
                        if ((Road.FullEmptyRoad[index,roadROL] == Road.Dollar) && (CarLeft == true) && (roadROL == 2))//там ли машина и доллар
                        {
                            Road.FullEmptyRoad[1,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[2,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[0,2] = Road.Empty;//очистка дороги
                            _dollar += 1;//+монета
                            SpawnDollar = false;//ничего не спавним
                            roadROL = 0;
                            SpawnLeft = false;
                            SpawnRight = false;
                            index = 0;
                            break;//выход из цикла(то есть жизнь 1 предмета кончилась)
                        }
                        else if ((Road.FullEmptyRoad[index,roadROL] == Road.Dollar) && (CarRight == true) && (roadROL == 6))//там ли машина и доллар
                        {
                            Road.FullEmptyRoad[1,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[2,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[0,2] = Road.Empty;//очистка дороги
                            _dollar += 1;//+монета
                            SpawnDollar = false;//ничего не спавним
                            roadROL = 0;
                            SpawnLeft = false;
                            SpawnRight = false;
                            index = 0;
                            break;//выход из цикла(то есть жизнь 1 предмета кончилась)
                        }
                    }
                    catch
                    {
                        if ((SpawnLeft == true) && (CarLeft == true))
                        {
                            Road.FullEmptyRoad[1,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[2,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[0,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[1,6] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[2,6] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[0,6] = Road.Empty;//очистка дороги
                            _dollar += 1;//+монета
                            SpawnDollar = false;//ничего не спавним
                            roadROL = 0;
                            SpawnLeft = false;
                            SpawnRight = false;
                            index = 0;
                            break;//выход из цикла(то есть жизнь 1 предмета кончилась)
                        }
                        else if ((SpawnRight == true) && (CarRight == true))
                        {
                            Road.FullEmptyRoad[1,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[2,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[0,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[1,6] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[2,6] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[0,6] = Road.Empty;//очистка дороги
                            _dollar += 1;//+монета
                            SpawnDollar = false;//ничего не спавним
                            roadROL = 0;
                            SpawnLeft = false;
                            SpawnRight = false;
                            index = 0;
                            break;//выход из цикла(то есть жизнь 1 предмета кончилась)
                        }
                    }    
                    try
                    {

                    
                        Road.FullEmptyRoad[index,roadROL] = Road.Dollar;
                        index = index + 1;
                        Road.FullEmptyRoad[index-1,roadROL] = Road.Dollar;
                    }
                    catch
                    {
                        continue;
                    }    
                    Thread.Sleep(500);
                    
                    

                }    

            }
        }
        public int GetDollars()//для надписи сколько монет
        {
            return _dollar;
        }

        
    }
}
