using lab2;

namespace lab3.DB.Repositories.Base
{
    public interface IPlayerRepository
    {
        IEnumerable<BasePlayer> GetAllPlayers();
        BasePlayer GetById(int id);
        BasePlayer GetByName(string name);
        void Create(BasePlayer player);
        void Delete(int id);
        void UpdateId(BasePlayer player, int newId);
        void UpdatePts(BasePlayer player, int newCurrrentRating);
        void UpdateName(BasePlayer player, string newname);
    }
}
