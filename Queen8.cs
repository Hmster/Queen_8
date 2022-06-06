using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queen_8
{
    internal class Queen8
    {
        /// <summary>
        /// инициализация доски
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        internal string[,] InitField(string[,] field)
        {
            string[] name = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };

            for (int i = 0; i < field.GetLength(0)-1; i++)
            {
                field[i, 0] = (8-i).ToString();
            }

            for (int j = 0; j < field.GetLength(1)-1; j++)
            {
                field[8, j+1] = name[j];
            }

            for (int i =0; i < field.GetLength(0)-1; i++)
            {
                for (int j = 1; j < field.GetLength(1); j++)
                {
                    field[i, j] = "0";
                }
            }
            return field;
        }

        internal void PutQueen(string[,] field, int[] position)
        {
            for (int i = 0; i < position.Length; i++)
            {
                int indexX = i+1;
                int indexY = position[i];
                field[indexX, indexY] = "Q";
            }
        }

        internal int[] GetPositions(string data)
        {
            int.TryParse(data, out int number);
            int lastIndex = number * 8 - 1;
            int firstIndex = number * 8 - 8;
            int[] pos = new int[8];
            for (int i = 0; i < 8; i++)
                pos[i] = position.ElementAt(firstIndex + i);
            return pos;
        }

        internal List<int> position = new List<int>();


        public byte[] p = new byte[9];
        // p[0] - счетчик пересечений в расстановке
        // p[1] - номер горизонтали на вертикали a. Если p[1]=5, то это клетка а5
        // p[2] - номер горизонтали на вертикали b. Если p[2]=8, то это клетка b8
        // ...
        // p[8] - номер горизонтали на вертикали h. Если p[8]=3, то это клетка h3
        // Примеры:
        // {0,5,8,4,1,7,2,6,3};  = 28 непересечений
        // {0,2,5,7,1,3,8,6,4};  = 28
        // {0,2,4,7,1,3,8,6,5};  = 25 неперсечений
        // {0,2,4,6,8,1,3,5,7};  = 25
        // {0,2,3,4,5,6,7,8,1};  = 6 неперсечений
        // Необходима проверка 28 пар точек: 7 (1-я с остальными) + 
        // 6 (2-я с остальными) + ... + 1 (7-я с 8-й) = 28
        // Проверка 28 пар клеток с координатами:
        // (p[j1],j1) и (p[j2],j2) - (строка, столбец)

        /// <summary>
        /// проверка расстановки
        /// </summary>
        public void provP()
        {
            bool b1, b2, b3;
            for (int j1 = 1; j1 < 8; j1++)
                for (int j2 = (j1 + 1); j2 <= 8; j2++)
                {
                    b1 = (p[j1] != p[j2]); // не на одной горизонтали (строке)
                    b2 = (p[j2] - p[j1]) != (j2 - j1);   // не на одной диагонали (45 град)
                    b3 = (p[j1] + j1) != (p[j2] + j2);   // не на одной диагонали (135 град)
                    if (b1 && b2 && b3)
                        p[0]++;   // если не бьют друг друга
                }
        }

        /// <summary>
        /// проверка основных диагоналей
        /// </summary>
        /// <returns></returns>
        public bool provG()
        {
            bool b = false;
            for (int i = 1; i <= 8; i++)
            {
                if ((i == p[i]) | ((i + p[i]) == 9))
                {
                    b = true;
                }
                if (b)
                    break; // выход из цикла
            }
            return b;
        }

        /// <summary>
        /// расстановка ферзей
        /// </summary>
        /// <returns></returns>
        public string provM()
        {
            int count = 0;
            StringBuilder variants = new StringBuilder();
            
            for (byte j1 = 1; j1 <= 8; j1++)
            {
                p[1] = j1;
                for (byte j2 = 1; j2 <= 8; j2++)
                {
                    p[2] = j2;
                    for (byte j3 = 1; j3 <= 8; j3++)
                    {
                        p[3] = j3;
                        for (byte j4 = 1; j4 <= 8; j4++)
                        {
                            p[4] = j4;
                            for (byte j5 = 1; j5 <= 8; j5++)
                            {
                                p[5] = j5;
                                for (byte j6 = 1; j6 <= 8; j6++)
                                {
                                    p[6] = j6;
                                    for (byte j7 = 1; j7 <= 8; j7++)
                                    {
                                        p[7] = j7;
                                        for (byte j8 = 1; j8 <= 8; j8++)
                                        {
                                            p[8] = j8;
                                            p[0] = 0; 
                                            provP();
                                            if (p[0] == 28)
                                            {
                                                bool b = provG(); 
                                                b = false; 
                                                if (!b)
                                                {
                                                    count++;
                                                    variants.Append($"{count}) ");
                                                    for (int i = 1; i <= 8; i++)
                                                    {
                                                        variants.Append($" {p[i]} ");
                                                        position.Add(p[i]);
                                                    }
                                                    variants.Append("\n");
                                                }
                                            }
                                        }  
                                    }
                                }
                            }
                        }
                    }
                }
            }
            variants.Append($"Всего расстановок - {count}");

            return variants.ToString();
        }

        
    }
}
