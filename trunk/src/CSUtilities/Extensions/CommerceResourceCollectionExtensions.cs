using System.Data.OleDb;
using Microsoft.CommerceServer.Runtime.Configuration;

namespace CSUtilities.Extensions
{
    public static class CommerceResourceCollectionExtensions
    {
        public static string GetTransactionDbConnectionString(this CommerceResourceCollection resources)
        {
            string result =
                resources["transactions"]["connstr_db_Transactions"].ToString();

            return result;
        }

        public static string GetCatalogDbConnectionString(this CommerceResourceCollection resources)
        {
            string result =
                resources["Product Catalog"]["connstr_db_Catalog"].ToString();

            return result;
        }

        public static string ForSqlConnection(this string oleDbConnectionString)
        {
            var builder = new OleDbConnectionStringBuilder(oleDbConnectionString);
            builder.Remove("provider");

            return builder.ConnectionString;
        }
    }
}