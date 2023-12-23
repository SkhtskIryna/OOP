using System;// імпортуємо (підключаємо) простір імен, щоб зробити його класи, методи і об'єкти доступними без повного кваліфікатора простору імен
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ClassShowCase//підключаємо простір імен
{
    public class GameAccount//створення класу GameAccount
    {
        public int GamesCount;//створення полів
        public string UserName;

        public int CurrentRating//створюємо CurrentRating як властивість через модифікатор get
        {
            get
            {
                int rating = 0;

                foreach (var item in Result)
                {
                    rating += item.Rating;
                }

                if (rating < 0)
                {
                    throw new Exception("The rating for which they are playing cannot be negative");
                }
                else if (rating <= 1)
                {
                    rating = 1;
                }

                return rating;
            }
        }

        private List<GameResult> Result;//оголошення приватного поля Result зі списком об'єктів GameResult

        public GameAccount(string userName, int initialRating)//створення конструктура (метода) класу GameAccount для створення початкових значень об'єкта
        {
            UserName = userName;
            GamesCount = 0;

            Result = new List<GameResult>();//записуємо до списку
        }

        public void WinGame(GameAccount opponent, int rating, Game num)//оголошення методу виграшу
        {
            GamesCount++;
            rating -= 1;

            //додавання нового об'єкту GameResult до списку Result
            Result.Add(new GameResult
            {
                OpponentName = opponent.UserName,
                Rating = rating,
                IsWin = true
            });

        }

        public void LoseGame(GameAccount opponent, int rating, Game num)//оголошення методу програшу
        {
            GamesCount++;
            rating = 1;

            Result.Add(new GameResult
            {
                OpponentName = opponent.UserName,
                Rating = rating,
                IsWin = false
            });
        }

        public void GetStats()//оголошення методу виведення результатів (списку)
        {
            Console.WriteLine($"Player statistics {UserName}");
            Console.WriteLine("________________________________________________________________________\n" +
                            $"|  Round № |     |   Opponent   |       | Reting |       |    Result    |  \n" +
                              "------------------------------------------------------------------------");

            for (int i = 0; i < Result.Count; i++)
            {
                var result = Result[i];
                string outcome = result.IsWin ? "Won" : "Lost";
                Console.WriteLine($"| {i + 1} \t   |\t |\t{result.OpponentName}\t|\t|   {result.Rating}   |\t | {outcome}\t\t|");
            }

            Console.WriteLine($"Number of games: {GamesCount}, Current rating: {CurrentRating}");
            Console.WriteLine();
        }
    }

    public class GameResult//створюємо класс GameResult для подальшої роботи з властивостями 
    {
        public string OpponentName { get; set; }//оголошуємо властивості, зчитуємо та записуємо
        public int Rating { get; set; }
        public bool IsWin { get; set; }
    }

    public class Game
    {
        private static int accoundNumberInd = 12345;//задаємо унікальний індентифікатор
        public string Number { get; }

        public Game(int Number)
        {
            this.Number = accoundNumberInd.ToString();//призначаємо рядок, який представляє індентифікатор
            accoundNumberInd++;
        }
    }

    class Program 
    {
        public static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t        _______        ____         ___   ___      _______ \n" +
                              "\t      /  _____|       /   \\        |   \\/   |    |   ____|\n" +
                              "\t     |  |  __        /  ^  \\       |  \\  /  |    |  |__   \n" +
                              "\t     |  | |_ |      /  /_\\  \\      |  |\\/|  |    |   __|  \n" +
                              "\t     |  |__| |     /  _____  \\     |  |  |  |    |  |____ \n" +
                              "\t      \\______|    /__/     \\__\\    |__|  |__|    |_______|\n");

            Console.ResetColor();

            Game num = new Game(12345);

            GameAccount player1 = new GameAccount("Ira", 1);//створюємо об'єкти та початкові значення для них
            GameAccount player2 = new GameAccount("Diana", 1);

            int numberOfIterations = 1;
            Console.WriteLine("\t-------------------------------------------------------------\n" +
                            $"\t\t                 Round {numberOfIterations++}         \n" +
                              "\t-------------------------------------------------------------");

            player1.WinGame(player2, 1, num);//викликаємо метод виграшу на об'єкті першого гравця
            player1.LoseGame(player2, 1, num);
            player1.WinGame(player2, 1, num);

            player2.LoseGame(player1, 1, num);//викликаємо метод програшу на об'єкті другого гравця

            Console.WriteLine($"\nPlayer 1 - {player1.UserName}\nCurrent rating: {player1.CurrentRating}\n");
            Console.WriteLine($"\nPlayer 2 - {player2.UserName}\nCurrent rating: {player2.CurrentRating}\n");

            player1.GetStats();//викликаємо метод виведення списку на об'єктах
            player2.GetStats();

        }
    }
}
