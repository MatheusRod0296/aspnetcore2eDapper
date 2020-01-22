using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repository;

namespace BaltaStore.Tests.Mocks
{
    public class MockCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
             return false;
        }

        public void Save(Customer customer)
        {
             
        }
    }
}