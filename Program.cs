using System;
using System.Threading;//Для поточного программирования

namespace NuniTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Thread Thread1 = new Thread(Car.Spawn);//новый поток
            Thread1.Start();//запускаем его
            
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
        static Random rnd = new Random();//рандом

        static public bool SpawnDollar = false;//спавнить ли сейчас доллар
        static public bool SpawnSpike = false;//спавнить ли сейчас колючку
        static public bool SpawnItem = false;//спавнится ли сейчас предмет
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
                
            } 
            if((Console.ReadKey().Key == ConsoleKey.A) )
            {
                Console.Clear();
                Road.FullEmptyRoad[2,2] = Road.Car;
                Road.FullEmptyRoad[2,6] = Road.Empty;
                Road.WriteEmptyRoad();
                CarLeft = true;//условия где машина
                CarRight = false;//условия где машина
                
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
            if (num <= 5)//если 50 процентов
            {
                SpawnDollar = true;//спавним доллар
                SpawnItem = true;
                SpawnSpike = false;
            }
            else
            {
                SpawnDollar = false;//иначе нет
                SpawnItem = false;
                SpawnSpike = false;
            }

            Road.FullEmptyRoad[index,2] = Road.Dollar;//доллар вверху
            if (SpawnDollar == true && SpawnItem == true)//мы спавним что то
            {
                
                while(true)//цикл перемещения
                {
                    index += 1;//индекс куда спавнить
                    try//на всякий вдруг индекс зашкалит
                    {
                        if ((Road.FullEmptyRoad[1,2] == Road.Dollar) && (CarLeft == true))//там ли машина и доллар
                        {
                            Road.FullEmptyRoad[1,2] = Road.Empty;//очистка дороги
                            Road.FullEmptyRoad[2,2] = Road.Empty;//очистка дороги
                            Thread.Sleep(500);
                            Road.FullEmptyRoad[0,2] = Road.Empty;//очистка дороги
                            _dollar += 1;//+монета
                            break;//выход из цикла(то есть жизнь 1 предмета кончилась)
                        }
                    }
                    catch
                    {
                        Thread.Sleep(1);//а что мне нужно было сюда вставлять?)
                    }    
                    Road.FullEmptyRoad[1,2] = Road.Dollar;//спавним(да когда будем увеличивать дорогу придется поменять)
                    Thread.Sleep(500);//задержка 500 милисекунд(0,5 сек)
                }    
                SpawnDollar = false;//ничего не спавним
                SpawnItem = false;//ничего не спавним
            }
        }
        public int GetDollars()//для надписи сколько монет
        {
            return _dollar;
        }

        
    }
}
