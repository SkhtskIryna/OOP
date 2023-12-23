using lab2;
using lab3.DB.Repositories.Base;

namespace lab3.DB.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private DbContext context;
        public PlayerRepository()
        {
            context = new DbContext();
        }

        public IEnumerable<BasePlayer> GetAllPlayers()
        {
            return context.Players;
        }
        public BasePlayer GetById(int ID)
        {
            return context.Players.FirstOrDefault(player => player.ID == ID);
        }
        public BasePlayer GetByName(string name)
        {
            return context.Players.FirstOrDefault(player => player.UserName == name);
        }

        public void Create(BasePlayer player)
        {
            context.Players.Add(player);
        }

        public void Delete(int id)
        {
            BasePlayer player = context.Players.FirstOrDefault(player => player.ID == id);
            if (player != null)
            {
                context.Players.Remove(player);
            }
        }

        public void UpdateId(BasePlayer player, int newId)
        {
            player.ID = newId;
        }

        public void UpdatePts(BasePlayer player, int newCurrrentRating)
        {
            player.CurrentRating = newCurrrentRating;
        }

        public void UpdateName(BasePlayer player, string newname)
        {
            player.UserName = newname;
        }
    }
}
