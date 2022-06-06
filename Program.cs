using System;

namespace Queen_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queen8 q8 = new Queen8();
            string[,] field = new string[9, 9];

            q8.InitField(field);

            Console.WriteLine();

            tstart = DateTime.Now;
            string result = q8.provM();
            tfinish = DateTime.Now;

            Console.WriteLine(result);
            TimePoisk();

            Console.WriteLine("\nВведите вариант для расстановки:");
            string data = Console.ReadLine();
            int[] pos = q8.GetPositions(data);
            for (int i = 0; i < pos.Length; i++)
                Console.Write(pos[i]+ " ");
            Console.WriteLine();
            q8.PutQueen(field, pos);
            PrintField(field);


        }

        public static DateTime tstart, tfinish;

        internal static void PrintField(string[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++, Console.WriteLine())
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == "Q")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("{0,3}", field[i, j]);

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("{0,3}", field[i, j]);
                    }
                }
        }

        public static void TimePoisk()
        {
            int dt, ds, dm, dh;
            dt = tfinish.Hour * 3600 + tfinish.Minute * 60 + tfinish.Second - tstart.Hour * 3600 - tstart.Minute * 60 - tstart.Second;
            dh = dt / 3600;
            dm = (dt - dh * 3600) / 60;
            ds = (dt - dh * 3600 - dm * 60);
            if (dt < 60)
                Console.WriteLine("Время поиска: секунд - {0}", ds);
            else if (dt < 3600)
                Console.WriteLine("Время поиска: минут - {0}, секунд - {1}", dm, ds);
            else
                Console.WriteLine("Время поиска: часов - {0}, минут - {1}, секунд - {2}", dh, dm, ds);
        }
    }
}
