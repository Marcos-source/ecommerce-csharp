using Npgsql;

namespace C_
{
    public class Connection
    {
        NpgsqlConnection conex = new NpgsqlConnection();
        static string host = "localhost";
        static string user = "postgres";
        static string pass = "1234";
        static string database = "henryapp";
        static string port = "5432"; 


        String conectionUrl = $"server={host}; port={port}; user id={user}; password={pass}; database = {database}";

        public NpgsqlConnection connect(){
            try
            {
             conex.ConnectionString = conectionUrl; 
             conex.Open();
             Console.WriteLine("conection ready");  
            }
            catch (NpgsqlException e)
            {
               Console.WriteLine(e.ToString()); 
            }
            return conex;
        }
    }
}