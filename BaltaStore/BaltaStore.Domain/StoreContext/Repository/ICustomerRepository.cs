using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;

namespace BaltaStore.Domain.StoreContext.Repository
{
    public interface ICustomerRepository
    {
         bool CheckDocument(string document);
         bool CheckEmail(string email);

         void Save(Customer customer);
         
         CustomerOrdersCountResult GetCustomerOrdersCount(string document);

         IEnumerable<ListCustomerResultQuery> Get();
         GetCustomerResultQuery Get(Guid id);

         IEnumerable<ListCustomerOrdersResultQuery> GetOrders(Guid id);
    }
}