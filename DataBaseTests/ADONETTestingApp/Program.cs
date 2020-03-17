using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection_string = "Data Source=(localdb)\\MSSQLLocalDB;" +
                                  "Initial Catalog=EmployeesDB;" +
                                  "Integrated Security=True;" +
                                  "Connect Timeout=30;" +
                                  "Encrypt=False;" +
                                  "TrustServerCertificate=False;" +
                                  "ApplicationIntent=ReadWrite;" +
                                  "MultiSubnetFailover=False";

            //DbConnectionStringBuilder sb = new DbConnectionStringBuilder() { ConnectionString = connection_string };

            //SqlConnectionStringBuilder sql_sb = new SqlConnectionStringBuilder(connection_string);

            //sql_sb.DataSource = "(localdb)\\MSSQLLocalDB";

            //sql_sb.InitialCatalog = "TestDB";

            //sql_sb.IntegratedSecurity = false;

            //sql_sb.UserID = "Login";

            //sql_sb.Password = "Pass";

            //var new_connection_string = sql_sb.ConnectionString;

            var connection_strings = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }
        private const string __SqlInsertToPeopleTable = "@INSERT INTO [dbo.]";
        //Тут должен быть код с БД
        private const string __SqlCreateTable = @"фывфыв";
        private static void ExecuteNonQuery(string ConnectionStrings)
        {
            using (var connection = new SqlConnection(ConnectionStrings))
            {
                connection.Open();

                //var create_table_command = new SqlCommand(__SqlCreateTable, connection);
                var insert_data_command = new SqlCommand();
            }
                
        }
    }
}
