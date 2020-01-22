using BaltaStore.Domain.StoreContext.Services;

namespace BaltaStore.Tests.Mocks
{
    public class MockEmailService : IEMailServices
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}