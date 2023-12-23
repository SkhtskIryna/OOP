using lab3.DB.Services.Base;
using lab3.DB.Services;
using lab3.ShowInfo.Base;
using lab3.ShowInfo;

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

        public BasePlayer( string UserName = "Veronika", int rating = 10, int ID = 5)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.Rating = rating;
            this.CurrentRating = rating;

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

        public void Run() 
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

            IShowInfo createAcc = new CreateAccount();
            IShowInfo allAccounts = new GetAllAccounts();
            IShowInfo playedgamesbyplayer = new PlayedGamesByPlayer();
            IShowInfo play = new Play();
            IShowInfo games = new ReadAllGames();

            BasePlayer p1 = null, p2 = null;
            int count = 0;

            //int temp = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                createAcc.Show();
                allAccounts.Show();
                playedgamesbyplayer.Show();
                games.Show();
                play.Show();

                List<Action<Service>> actions = new List<Action<Service>>
                {
                    service => games.Action(service),
                    service => allAccounts.Action(service),
                    service => createAcc.Action(service),
                    service => playedgamesbyplayer.Action(service),
                    service => play.Action(service)
                };

                Shuffle(actions);

                Service yourService = new Service();

                foreach (var action in actions)
                {
                    action(yourService);
                }

                //Console.Clear();
            }

        }

        public void Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}