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

        public CustomerOrdersCountResult GetCustomerOrdersCount(string Document)
        {
             var script = @"Select Custo.Id 
                            , FirstName || ' ' || LastName AS Name
                            ,Document
                            ,Count(o.Id) as Orders
                        
                        from Customer as Custo
                        left join [Order] as o
                        on Custo.Id = o.CustomerId
                        where Custo.Document = @Document";

            return _context.Connection.Query<CustomerOrdersCountResult>(script, new {Document}).FirstOrDefault();
        }

        public void Save(Customer customer)
        {
           
            var scriptCustomer = @"insert into Costumer
                                    (
                                        id
                                        ,FirstName
                                        ,LastName
                                        ,Document
                                        ,Email
                                        ,Pohone

                                    )

                                    Values 
                                    (
                                        @id
                                        ,@FirstName
                                        ,@LastName
                                        ,@Document
                                        ,@Email
                                        ,@Pohone
                                    )";

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
            

           _context.Connection.Execute(scriptCustomer, customer);

           foreach (var adress in customer.Adresses)
           {
               _context.Connection.Execute(scriptAdress, adress);
           }




        }
    }
}