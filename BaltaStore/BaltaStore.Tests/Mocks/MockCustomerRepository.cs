using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
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

        public IEnumerable<ListCustomerResultQuery> Get()
        {
            throw new NotImplementedException();
        }

        public GetCustomerResultQuery Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string Document)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListCustomerOrdersResultQuery> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
             
        }
    }
}