using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queen_8
{
    internal class Queen8
    {
        internal string[] name = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
        internal List<int> positionList = new ();
        internal byte[] places = new byte[9];


        /// <summary>
        /// инициализация доски
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        internal string[,] InitField(string[,] field)
        {

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

        /// <summary>
        /// отрисовка ферзей на доске
        /// </summary>
        /// <param name="field"></param>
        /// <param name="position"></param>
        internal static void PutQueen(string[,] field, int[] position)
        {
            for (int i = 0; i < position.Length; i++)
            {
                int indexX = i+1;
                int indexY = position.Length - position[i];
                field[indexY, indexX] = "Q";
            }
        }

        /// <summary>
        /// выбор варианта для отрисовки
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal int[] ChoosePositions(int number)
        {
            int firstIndex = number * 8 - 8;
            int[] pos = new int[8];
            for (int i = 0; i < 8; i++)
                pos[i] = positionList.ElementAt(firstIndex + i);
            return pos;
        }

        /// <summary>
        /// проверка расстановки
        /// </summary>
        internal void CheckP()
        {
            bool checkHor, checkDiag45, checkDiag135;
            for (int j1 = 1; j1 < 8; j1++)
                for (int j2 = (j1 + 1); j2 <= 8; j2++)
                {
                    checkHor = (places[j1] != places[j2]); // не на одной горизонтали
                    checkDiag45 = (places[j2] - places[j1]) != (j2 - j1);   // не на одной диагонали (45 град)
                    checkDiag135 = (places[j1] + j1) != (places[j2] + j2);   // не на одной диагонали (135 град)
                    if (checkHor && checkDiag45 && checkDiag135)
                        places[0]++;   // если не бьют друг друга
                }
        }


        /// <summary>
        /// расстановка ферзей
        /// </summary>
        /// <returns></returns>
        internal string CheckMain()
        {
            int count = 0;
            StringBuilder variants = new ();
            
            for (byte j1 = 1; j1 <= 8; j1++)
            {
                places[1] = j1;
                for (byte j2 = 1; j2 <= 8; j2++)
                {
                    places[2] = j2;
                    for (byte j3 = 1; j3 <= 8; j3++)
                    {
                        places[3] = j3;
                        for (byte j4 = 1; j4 <= 8; j4++)
                        {
                            places[4] = j4;
                            for (byte j5 = 1; j5 <= 8; j5++)
                            {
                                places[5] = j5;
                                for (byte j6 = 1; j6 <= 8; j6++)
                                {
                                    places[6] = j6;
                                    for (byte j7 = 1; j7 <= 8; j7++)
                                    {
                                        places[7] = j7;
                                        for (byte j8 = 1; j8 <= 8; j8++)
                                        {
                                            places[8] = j8;
                                            places[0] = 0; 
                                            CheckP();

                                            if (places[0] == 28) // проверяем на кол-во несовпадений(всего должно быть 28 для верной расстановки)
                                            {
                                                count++;
                                                variants.Append($"{count}) ");
                                                for (int i = 1; i <= 8; i++)
                                                {
                                                    variants.Append($" {name[i - 1]}{places[i]} ");
                                                    positionList.Add(places[i]);
                                                }
                                                variants.Append('\n');
                                            }
                                        }  
                                    }
                                }
                            }
                        }
                    }
                }
            }
            variants.Append($"Number of variants - {count}");

            return variants.ToString();
        }
    }
}
