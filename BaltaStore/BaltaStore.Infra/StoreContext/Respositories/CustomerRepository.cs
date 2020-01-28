using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repository;
using BaltaStore.Infra.StoreContext.DataContext;
using Dapper;

namespace BaltaStore.Infra.StoreContext.Respositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
           var script = @"select case when EXISTS (
                                select id from Customer where Document = @document
                            )
                            then cast(1 as bit)
                            else cast(0 as bit) end";

            return _context.Connection.Query<bool>(script, new {document}).FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            var script = @"select case when EXISTS (
                                    select id from Customer where Email = @email
                                )
                                then cast(1 as bit)
                                else cast(0 as bit) end";

            return _context.Connection.Query<bool>(script, new {email}).FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
             var script = @"Select Custo.Id 
                            , FirstName || ' ' || LastName AS Name
                            ,Document
                            ,Count(o.Id) as Orders
                        
                        from Customer as Custo
                        left join [Order] as o
                        on Custo.Id = o.CustomerId
                        where Custo.Document = @document";

            return _context.Connection.Query<CustomerOrdersCountResult>(script, new {document}).FirstOrDefault();
        }

        public IEnumerable<ListCustomerResultQuery> Get()
        {
             var script = @"Select Id 
                            , FirstName || ' ' || LastName AS Name
                            ,Document
                            ,Email
                        
                        from Customer";

            return _context.Connection.Query<ListCustomerResultQuery>(script);
        }

        public void Save(Customer customer)
        {
           
            

            var scriptAdress = @"INSERT into Adress
                                    (	id
                                        ,CostumerId
                                        ,Number
                                        ,Complement
                                        ,District
                                        ,City
                                        ,state
                                        ,Country
                                        ,Zipcode
                                        ,Type)

                                        values(
                                             @Id
                                            ,@CostumerId
                                            ,@Number
                                            ,@Complement
                                            ,@District
                                            ,@City
                                            ,@state
                                            ,@Country
                                            ,@Zipcode
                                            ,@Type
                                        )";

            var scriptCustomer = @"insert into Customer
                                    (
                                        Id
                                        ,FirstName
                                        ,LastName
                                        ,Document
                                        ,Email
                                        ,Pohone

                                    )

                                    Values 
                                    (
                                         @Id
                                        ,@FirstName
                                        ,@LastName
                                        ,@Document
                                        ,@Email
                                        ,@Phone
                                    )";


            _context.Connection.Execute(scriptCustomer,
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.ToString(),
                    Email = customer.Email.ToString(),
                    Phone = customer.Phone
                }); 

           foreach (var adress in customer.Adresses)
           {
               _context.Connection.Execute(scriptAdress, adress);
           }




        }

        public GetCustomerResultQuery Get(Guid id)
        {
            var script = @"Select Id 
                            , FirstName || ' ' || LastName AS Name
                            ,Document
                            ,Email
                        
                        from Customer where [Id] = @id";

            return _context.Connection.Query<GetCustomerResultQuery>(script, new {id}).FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrdersResultQuery> GetOrders(Guid id)
        {
            //TODO: implementar Query
           var script = @"";

            return _context.Connection.Query<ListCustomerOrdersResultQuery>(script, new {id});
        }
    }
}