using Core;

namespace BLL
{
    public interface IShopCartManager
    {
        ShopCart Get();

        void Add(string reference, int quantity = 1);

        void Remove(string reference, int quantity = 1);

        void Clear();

        int Count();

        void Save();
    }
}
