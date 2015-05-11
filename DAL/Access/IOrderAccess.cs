namespace DAL
{
    public interface IOrderAccess
    {
        void Checkout(Order order, Client client);
    }
}
