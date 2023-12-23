using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    public class VipPlayer : GameAccount
    {
        public VipPlayer(string userName, int CurrentRating) : base(userName, CurrentRating)
        {
        }

        public override void LoseGame(GameAccount opponent, Game game)
        {
            CurrentRating -= game.Rating / 2;
        }

        public override void WinGame(GameAccount opponent, Game game)
        {
            CurrentRating += game.Rating * 2;
        }
    }
}
