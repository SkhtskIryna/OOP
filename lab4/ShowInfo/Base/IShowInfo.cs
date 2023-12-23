using lab3.DB.Services;

namespace lab3.ShowInfo.Base
{
    internal interface IShowInfo
    {
        public void Show();
        public void Action(Service service);
    }
}
