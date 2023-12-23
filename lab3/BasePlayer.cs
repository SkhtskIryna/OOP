using lab3.DB.Services.Base;
using lab3.DB.Services;

namespace lab2
{
    public class BasePlayer
    {
        public int ID { get; set; }
        public int GameId { get; set; }
        public string UserName;
        public string Opponent;
        public int Rating { get; }
        public string IsWin { get; set; }

        public List<GameStats> allGames = new List<GameStats>();

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

        public List<int> gameid;
        public List<GameStats> gameStats;

        public BasePlayer()
        {
            this.ID = ID;
            this.UserName = UserName;
            this.Rating = Rating;
            this.CurrentRating = CurrentRating;

            gameid = new List<int>();
        }

        public void PlayGame(BasePlayer opponent, string IsWin, Game game)
        {
            if (IsWin == "Win") {
                WinGame(opponent, game);
            }
            if (IsWin == "Lost") {
                LoseGame(opponent, game);
            }
            if (opponent != null)
            {
                var gamesession = new GameStats(GameId, Opponent, UserName, CurrentRating);
                allGames.Add(gamesession);
            }
        }
        public virtual void WinGame(BasePlayer opponent, Game game)
        {
            opponent.IsWin = "Lost";
            CurrentRating += game.Rating;
        }

        public virtual void LoseGame(BasePlayer opponent, Game game)
        {
            opponent.IsWin = "Win";
            CurrentRating -= game.Rating;
        }

        public void Run(VipPlayer player1, BasePlayer player2) 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t        _______        ____         ___   ___      _______ \n" +
                              "\t      /  _____|       /   \\        |   \\/   |    |   ____|\n" +
                              "\t     |  |  __        /  ^  \\       |  \\  /  |    |  |__   \n" +
                              "\t     |  | |_ |      /  /_\\  \\      |  |\\/|  |    |   __|  \n" +
                              "\t     |  |__| |     /  _____  \\     |  |  |  |    |  |____ \n" +
                              "\t      \\______|    /__/     \\__\\    |__|  |__|    |_______|\n");

            Console.ResetColor();

            IService service = new Service();
            Game newGame;

            int numberRound = 0;
            newGame = GameFactory.gameFactory(numberRound++, GameType.Solo, player1, player2, 1); 

            
            newGame.Play(player2, player1, "Win");
            newGame.Play(player2, player1, "Win");
            service.CreateGame(player1, player2, newGame);



            newGame = GameFactory.gameFactory(numberRound++, GameType.Base, player1, player2, 1); 
            newGame.Play(player2, player1, "Win");
            newGame.Play(player2, player1, "Lost");
            service.CreateGame(player1, player2, newGame);



            newGame = GameFactory.gameFactory(numberRound++, GameType.Training, player1, player2, 1);
            newGame.Play(player1, player2, "Lost");
            service.CreateGame(player1, player2, newGame);

            service.ReadAccounts();
            service.ReadGames();

            service.ReadAccountById(3);
            service.ReadPlayedGamesByPlayer(3);
            service.ReadAccountById(2);
            service.ReadPlayedGamesByPlayer(2);
            Console.ReadLine();
        }
    }
}