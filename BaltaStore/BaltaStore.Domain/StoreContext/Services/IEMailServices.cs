namespace BaltaStore.Domain.StoreContext.Services
{
    public interface IEMailServices
    {
         void Send(string to, string from, string subject, string body);
    }
}