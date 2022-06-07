using System;

namespace Queen_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Eight Queens Puzzle";

            Queen8 q8 = new ();
            string[,] field = new string[9, 9];

            q8.InitField(field);
            PrintField(field);
            Console.WriteLine("\n The eight queens puzzle:\n Place eight queens on an 8x8 chessboard such that none of them attack one another.\n All variants:");

            Console.WriteLine();

            tstart = DateTime.Now;
            string result = q8.CheckMain();
            tfinish = DateTime.Now;

            Console.WriteLine(result);
            TimeSearch();
            while (true)
            {
                Console.WriteLine("\nChoose variant to draw(1-92):");
                string data = Console.ReadLine();
                if (data == "x")
                    Environment.Exit(0);
                int number = ParseData(data);
                Console.Write("Queens places: ");
                int[] pos = q8.ChoosePositions(number);
                for (int i = 0; i < pos.Length; i++)
                    Console.Write(q8.name[i] + pos[i] + " ");
                Console.WriteLine();

                Queen8.PutQueen(field, pos);
                PrintField(field);
                q8.InitField(field);
            }


        }

        internal static DateTime tstart, tfinish;

        /// <summary>
        /// отрисовка доски в консоли
        /// </summary>
        /// <param name="field"></param>
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
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("{0,3}", field[i, j]);
                    }
                }
        }

        /// <summary>
        /// вывод затраченного времени на поиск вариантов
        /// </summary>
        internal static void TimeSearch()
        {
            int dt, ds, dm, dh;
            dt = tfinish.Hour * 3600 + tfinish.Minute * 60 + tfinish.Second - tstart.Hour * 3600 - tstart.Minute * 60 - tstart.Second;
            dh = dt / 3600;
            dm = (dt - dh * 3600) / 60;
            ds = (dt - dh * 3600 - dm * 60);
            if (dt < 60)
                Console.WriteLine("Search time: seconds - {0}", ds);
            else if (dt < 3600)
                Console.WriteLine("Search time: minutes - {0}, seconds - {1}", dm, ds);
            else
                Console.WriteLine("Search time: hours - {0}, minutes - {1}, second - {2}", dh, dm, ds);
        }

        internal static int ParseData(string data)
        {
            int number;
            bool check;
            do
            {
                check = int.TryParse(data, out number);
                if (!check || number < 1 || number > 92)
                {
                    Console.WriteLine("Enter correct number(1-92)");
                    data = Console.ReadLine();
                }
                else return number;
            }
            while (!check || number < 1 || number > 92);
            return number ;
        }
    }
}
