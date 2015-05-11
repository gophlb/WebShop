using Core;

namespace BLL
{
    public interface IOrderManager
    {
        void Add(ShopCart cart, ClientViewModel client);
    }
}
