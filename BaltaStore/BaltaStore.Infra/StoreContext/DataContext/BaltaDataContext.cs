using System;
using System.Data.SqlClient;
using BaltaStore.Shared;

namespace BaltaStore.Infra.StoreContext.DataContext
{
    public class BaltaDataContext: IDisposable
    {
        public SqlConnection Connection { get; set; }

        public BaltaDataContext(){
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose(){
            if(Connection.State != System.Data.ConnectionState.Closed){
                Connection.Close();
            }
        }
    }
}