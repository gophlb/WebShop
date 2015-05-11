namespace DAL
{
    public interface ICartAccess
    {
        Cart Get();

        void Add(Product product, int quantity = 1);

        void Remove(string reference, int quantity = 1);

        void Clear();

        int Count();

        void Save();
    }
}
