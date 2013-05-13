﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    class Methods
    {
        public static void AddBombs(String[,] workField)
        {
            // Ivo - n, rows, cols have no purpose in this method!
            // Venelin - n, rows, cols removed
            int gameFieldSize = workField.GetLength(0) - 2;
            int count = 0;
            Random randomNumber = new Random();
            int randomPlaceI;
            int randomPlaceJ;
            int minPercent = Convert.ToInt32(0.15 * (gameFieldSize * gameFieldSize));
            int maxPercent = Convert.ToInt32(0.30 * (gameFieldSize * gameFieldSize));
            int countMines = randomNumber.Next(minPercent, maxPercent);

            while (count <= countMines)
            {
                randomPlaceI = randomNumber.Next(0, gameFieldSize);
                randomPlaceJ = randomNumber.Next(0, gameFieldSize);
                randomPlaceI += 2;
                randomPlaceJ = 2 * randomPlaceJ + 2;

                while (workField[randomPlaceI, randomPlaceJ] != " " && workField[randomPlaceI, randomPlaceJ] != "-")
                {
                    randomPlaceI = randomNumber.Next(0, gameFieldSize);
                    randomPlaceJ = randomNumber.Next(0, gameFieldSize);
                    randomPlaceI += 2;
                    randomPlaceJ = 2 * randomPlaceJ + 2;
                }

                String randomDigit = Convert.ToString(randomNumber.Next(1, 6));
                workField[randomPlaceI, randomPlaceJ] = randomDigit;
                workField[randomPlaceI, randomPlaceJ + 1] = " ";
                count++;
            }
        }


        public static void PrintArray(String[,] workField)
        {
            // Venelin - rows and cols removed
            int rows = workField.GetLength(0);
            int cols = workField.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(workField[i, j]);
                    Console.WriteLine();
                }
            }
        }

        public static void PlayerTurn(String[,] workField, int countPlayed)
        {
            // Venelin - n, rows and cols removed
            // x and y coordinates can be made into structure
            int gameFieldSize = workField.GetLength(0) - 2;
            int rows = workField.GetLength(0);
            int cols = workField.GetLength(1);

            countPlayed++;
            Console.WriteLine("Please enter coordinates: ");
            String coordinates = Console.ReadLine();
            int x = int.Parse(coordinates.Substring(0, 1));
            int y = int.Parse(coordinates.Substring(2, 1));

            while ((x < 0 || x > (gameFieldSize - 1)) && (y < 0 || y > (gameFieldSize - 1)))
            {
                Console.WriteLine("Invalid move !");
                Console.WriteLine("Please enter coordinates: ");
                coordinates = Console.ReadLine();
                x = int.Parse(coordinates.Substring(0, 1));
                y = int.Parse(coordinates.Substring(2, 1));

            }

            x += 2;
            y = 2 * y + 2;

            while (workField[x, y] == "-" || workField[x, y] == "X")
            {
                Console.WriteLine("Invalid move! ");
                Console.WriteLine("Please enter coordinates: ");
                coordinates = Console.ReadLine();
                x = int.Parse(coordinates.Substring(0, 1));
                y = int.Parse(coordinates.Substring(2, 1));

                while ((x < 0 || x > (gameFieldSize - 1)) && (y < 0 || y > (gameFieldSize - 1)))
                {
                    Console.WriteLine("Invalid move !");
                    Console.WriteLine("Please enter coordinates: ");
                    coordinates = Console.ReadLine();
                    x = int.Parse(coordinates.Substring(0, 1));
                    y = int.Parse(coordinates.Substring(2, 1));

                }

                x += 2;
                y = 2 * y + 2;

            }

            int hitCoordinate = Convert.ToInt32(workField[x, y]);
            switch (hitCoordinate)
            {
                case 1: 
                    HitOne(x, y, rows, cols, workField);
                    break;
                case 2:
                    HitTwo(x, y, rows, cols, workField); 
                    break;
                case 3:
                    HitThree(x, y, rows, cols, workField); 
                    break;
                case 4: 
                    HitFour(x, y, rows, cols, workField); 
                    break;
                case 5: 
                    HitFive(x, y, rows, cols, workField); 
                    break;
            }

            PrintArray(workField);
            if (!IsGameOver(rows, cols, workField))
            {
                PlayerTurn(workField, countPlayed);
            }
            else
            {
                Console.WriteLine("Game over. Detonated mines: " + countPlayed);
            }
        }

        // Venelin - All Hit methods could be joined in one.
        public static void HitOne(int x, int y, int rows, int cols, String[,] workField)
        {
            workField[x, y] = "X";
            if (x - 1 > 1 && y - 2 > 1)
            {
                workField[x - 1, y - 2] = "X";
            }
            if (x - 1 > 1 && y < cols - 2)
            {
                workField[x - 1, y + 2] = "X";
            }
            if (x < rows - 1 && y < cols - 2)
            {
                workField[x + 1, y + 2] = "X";
            }
            if (x < rows - 1 && y - 2 > 1)
            {
                workField[x + 1, y - 2] = "X";
            }
        }

        public static void HitTwo(int x, int y, int rows, int cols, String[,] workField)
        {
            workField[x, y] = "X";
            HitOne(x, y, rows, cols, workField);
            if (y - 2 > 1)
            {
                workField[x, y - 2] = "X";
            }
            if (y < cols - 2)
            {
                workField[x, y + 2] = "X";
            }
            if (x - 1 > 1)
            {
                workField[x - 1, y] = "X";
            }
            if (x < rows - 1)
            {
                workField[x + 1, y] = "X";
            }
        }

        public static void HitThree(int x, int y, int rows, int cols, String[,] workField)
        {
            HitTwo(x, y, rows, cols, workField);
            if (x - 2 > 1)
            {
                workField[x - 2, y] = "X";
            }
            if (x < rows - 2)
            {
                workField[x + 2, y] = "X";
            }
            if (y - 4 > 1)
            {
                workField[x, y - 4] = "X";
            }
            if (y == 18)
            {
                workField[x, y + 2] = "X";

            }
            else if (y == 20)
            {
                workField[x, y] = "X";
            }
            else
            {
                if (y < cols - 3)
                {
                    workField[x, y + 4] = "X";
                }
            }
        }

        public static void HitFour(int x, int y, int rows, int cols, String[,] workField)
        {
            HitThree(x, y, rows, cols, workField);
            if (x - 2 > 1 && y - 2 > 1)
            {
                workField[x - 2, y - 2] = "X";
            }
            if (x - 1 > 1 && y - 4 > 1)
            {
                workField[x - 1, y - 4] = "X";
            }
            if (x - 2 > 1 && y < cols - 2)
            {
                workField[x - 2, y + 2] = "X";
            }
            if (x < rows - 1 && y - 4 > 1)
            {
                workField[x + 1, y - 4] = "X";
            }
            if (x < rows - 2 && y - 2 > 1)
            {
                workField[x + 2, y - 2] = "X";
            }
            if (x < rows - 2 && y < cols - 2)
            {
                workField[x + 2, y + 2] = "X";
            }
            if (y == 18)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y + 2] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y] = "X";
                }
            }
            else
            {

                if (x - 1 > 1 && y < cols - 3)
                {
                    workField[x - 1, y + 4] = "X";
                }

                if (x < rows - 1 && y < cols - 3)
                {
                    workField[x + 1, y + 4] = "X";
                }

            }
        }

        public static void HitFive(int x, int y, int rows, int cols, String[,] workField)
        {
            HitFour(x, y, rows, cols, workField);
            if (x - 2 > 1 && y - 4 > 1)
            {
                workField[x - 2, y - 4] = "X";
            }
            if (x < rows - 2 && y - 4 > 1)
            {
                workField[x + 2, y - 4] = "X";
            }
            if (y == 18)
            {
                if (x < rows - 2)
                {
                    workField[x + 2, y + 2] = "X";
                }
                if (x - 2 > 1)
                {
                    workField[x - 2, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    workField[x + 2, y] = "X";
                }
                if (x - 2 > 1)
                {
                    workField[x - 2, y] = "X";
                }

            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    workField[x + 2, y + 4] = "X";
                }
                if (x - 2 > 1 && y < cols - 3)
                {
                    workField[x - 2, y + 4] = "X";
                }
            }
        }

        public static bool IsGameOver(int rows, int cols, String[,] gameField)
        {
            bool isEnd = true;
            for (int i = 2; i < rows; i++)
            {
                for (int j = 2; j < cols; j++)
                {
                    if (gameField[i, j] == "1" || gameField[i, j] == "2" || gameField[i, j] == "3" || gameField[i, j] == "4" || gameField[i, j] == "5")
                    {
                        isEnd = false;
                        break;
                    }
                }
            }
            return isEnd;
        }
    }
}
