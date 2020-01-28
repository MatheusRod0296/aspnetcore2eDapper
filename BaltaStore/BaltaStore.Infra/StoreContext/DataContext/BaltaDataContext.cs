using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using BaltaStore.Shared;


namespace BaltaStore.Infra.StoreContext.DataContext
{
    public class BaltaDataContext: IDisposable
    {
        public SQLiteConnection Connection { get; set; }

        public BaltaDataContext(){            
            Connection = new SQLiteConnection(Settings.ConnectionString);
            try
            {
                Connection.Open();
            }catch(Exception ex)
            {

            }
            
        }

        public void Dispose(){
            if(Connection.State != System.Data.ConnectionState.Closed){
                Connection.Close();
            }
        }
    }
}