using System.ComponentModel;
using System.Security.AccessControl;
using lab2;
using Nest;
using program;

namespace lab2
{
    public class GameAccount
    {

        public string UserName;

        public int GamesCount = 1;
        public int Rating { get; }
        public string IsWin { get; set; }
        public string gameType { get; set; }
        public int rating;
        public int CurrentRating 
        {
            get
            {
                return rating;
            }
            set
            {
                {
                    rating = value;
                }
            }
        }

        private List<GameResult> Result;

        public GameAccount(string userName, int CurrentRating)
        {
            this.gameType = gameType;
            this.UserName = userName;
            this.Rating = Rating;
            this.CurrentRating = CurrentRating;
            this.IsWin = IsWin;

            Result = new List<GameResult>();
        }

        public void PlayGame(GameAccount opponent, string IsWin, Game game)
        {
            if (IsWin == "Win") {
                WinGame(opponent, game);
            }
            if (IsWin == "Lost") {
                LoseGame(opponent, game);
            }
            if (opponent != null)
            {
                opponent.Result.Add(new GameResult
                (
                    game.Type,
                    opponent.UserName,
                    game.Rating,
                    this.CurrentRating,
                    opponent.IsWin
                 ));
            }
        }
        public virtual void WinGame(GameAccount opponent, Game game)
        {
            opponent.IsWin = "Lost";
            CurrentRating += game.Rating;
        }

        public virtual void LoseGame(GameAccount opponent, Game game)
        {
            opponent.IsWin = "Win";
            CurrentRating -= game.Rating;
        }

        public void GetStats(int numberRound)
        {
            Console.WriteLine("________________________________________________________________________________________\n" +
                            $"|  Round   |     |   Opponent   |       | Rating |       |    Result    |      Type     |\n" +
                              "----------------------------------------------------------------------------------------");

            int i;
            for (i = 1; i <= Result.Count; i++)
            { 
                foreach (var item in Result)
                {
                    string outcome = item.IsWin;
                    Console.WriteLine($"| {i++} \t   |\t |\t{item.opponentName}\t|\t|   {item.Rating}    |\t | {outcome}\t\t|   {item.gameType}  |");
                }
            }
            Console.WriteLine($"Number of games: {numberRound}, Current rating: {CurrentRating}");
            Console.WriteLine();
        }

        public void Run(VipPlayer player1, GameAccount player2, GameAccount player3, PremiumPlayer player4) 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t        _______        ____         ___   ___      _______ \n" +
                              "\t      /  _____|       /   \\        |   \\/   |    |   ____|\n" +
                              "\t     |  |  __        /  ^  \\       |  \\  /  |    |  |__   \n" +
                              "\t     |  | |_ |      /  /_\\  \\      |  |\\/|  |    |   __|  \n" +
                              "\t     |  |__| |     /  _____  \\     |  |  |  |    |  |____ \n" +
                              "\t      \\______|    /__/     \\__\\    |__|  |__|    |_______|\n");

            Console.ResetColor();

            int numberRound = 0;
            Console.WriteLine("\t-------------------------------------------------------------\n" +
                            $"\t\t                 Round {numberRound+=1}         \n" +
                              "\t-------------------------------------------------------------");

            Game newGame;
            SoloGame soloGame = new SoloGame(1, player1, player2, 1, "Solo", 2);

            newGame = GameFactory.gameFactory(numberRound, GameType.Solo, player1, player2, 1, "Solo", 3);

            newGame.Start();
            newGame.Play(player2, player1, "Win");
            newGame.Play(player2, player3, "Lost");
            newGame.Play(player2, player1, "Win");
            soloGame.PlaySolo(numberRound);
            newGame.End();

            Console.WriteLine("\t-------------------------------------------------------------\n" +
                            $"\t\t                 Round {numberRound+=1}         \n" +
                              "\t-------------------------------------------------------------");

            newGame = GameFactory.gameFactory(numberRound, GameType.Base, player1, player2, 1, "Base", 2);
            newGame.Start();
            newGame.Play(player2, player1, "Win");
            newGame.Play(player3, player2, "Win");
            newGame.Play(player2, player1, "Lost");
            newGame.End();

            Console.WriteLine("\t-------------------------------------------------------------\n" +
                            $"\t\t                 Round {numberRound+=1}         \n" +
                              "\t-------------------------------------------------------------");

            newGame = GameFactory.gameFactory(numberRound, GameType.Training, player1, player2, 1, "Training", 8);
            newGame.Start();
            newGame.Play(player3, player2, "Lost");
            newGame.End();

            Console.WriteLine("\t-------------------------------------------------------------\n" +
                          $"\t\t                 Round {numberRound += 1}         \n" +
                            "\t-------------------------------------------------------------");

            newGame = GameFactory.gameFactory(numberRound, GameType.Training, player1, player2, 1, "Solo", 3);
            newGame.Start();
            newGame.Play(player2, player4, "Win");
            newGame.End();

            Console.WriteLine($"\nPlayer 1 - {player1.UserName}\nCurrent rating: {player1.CurrentRating}\n");
            Console.WriteLine($"\nPlayer 2 - {player2.UserName}\nCurrent rating: {player2.CurrentRating}\n");
            Console.WriteLine($"\nPlayer 3 - {player3.UserName}\nCurrent rating: {player3.CurrentRating}\n");
            Console.WriteLine($"\nPlayer 4 - {player4.UserName}\nCurrent rating: {player4.CurrentRating}\n");

            Console.WriteLine($"Player statistics {player1.UserName}");
            player1.GetStats(numberRound);
            Console.WriteLine($"Player statistics {player4.UserName}");
            player2.GetStats(numberRound);
            Console.WriteLine($"Player statistics {player3.UserName}");
            player3.GetStats(numberRound);
            Console.WriteLine($"Player statistics {player2.UserName}");
            player4.GetStats(numberRound);

            Console.ReadLine();
        }
    }
}