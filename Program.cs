using System;

class Games
{
    
    static void Main()
    {
        string [,,] game = { { { "|", " ", "|", " ", "|" }, { "|", " ", "|", " ", "|" }, { "|", " ", "|", "█", "|" } } };
        string[,,] game2 = { { { "|", " ", "|", " ", "|" }, { "|", " ", "|", " ", "|" }, { "|", "█", "|", " ", "|" } } };
        string[,,] game3 = { { { "|", "$", "|", " ", "|" }, { "|", " ", "|", " ", "|" }, { "|", " ", "|", "█", "|" } } };
        string[,,] game4 = { { { "|", " ", "|", "$", "|" }, { "|", " ", "|", " ", "|" }, { "|", "█", "|", " ", "|" } } };
        int value = 1;
        int rand;
        int rand2;
        Random rnd = new Random();

        for(int i=0; i<game.GetLength(0);i++)
        {
            for(int j=0; j<game.GetLength(1); j++)
            {
                for(int k = 0; k < game.GetLength(2); k++)
                {
                    Console.Write(game[i, j, k] + " ");
                    
                }
                Console.WriteLine();
            }
            
        }
        while (true)
        {
            rand = rnd.Next(0, 2);
            if (rand == 1)
            {
                rand2 = rnd.Next(0, 2);
            }
            Console.ReadKey();
            if (Console.ReadKey().Key == ConsoleKey.D)
            {
                Console.Clear();
                
                for (int i = 0; i < game.GetLength(0); i++)
                {
                    for (int j = 0; j < game.GetLength(1); j++)
                    {
                        for (int k = 0; k < game.GetLength(2); k++)
                        {
                            Console.Write(game[i, j, k] + " ");

                        }
                        Console.WriteLine();
                    }

                }
            }
            else if (Console.ReadKey().Key == ConsoleKey.A)
            {

                Console.Clear();
                for (int i = 0; i < game2.GetLength(0); i++)
                {
                    for (int j = 0; j < game2.GetLength(1); j++)
                    {
                        for (int k = 0; k < game2.GetLength(2); k++)
                        {
                            Console.Write(game2[i, j, k] + " ");

                        }
                        Console.WriteLine();
                     }

                }
                
            }
        }

    }
}