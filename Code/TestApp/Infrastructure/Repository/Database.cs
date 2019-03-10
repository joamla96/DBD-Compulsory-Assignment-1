using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace Infrastructure.Repository
{
	public class Database : IDisposable
	{
		private IDbConnection connection;
        private string conString;

		public Database()
		{
            conString = "Server=ssh.jalawebs.com,1433;Database=;Persist Security Info=False;User ID=sa;Password=Sj@0coL!5Cn5Ia6i;MultipleActiveResultSets = False; Encrypt = True;";


            connection = new SqlConnection(conString);
		}

		public IEnumerable<t> ExcetueSP<t>(string name, DynamicParameters parameters = null)
		{
			var result = connection.Query<t>(name, parameters, commandType: CommandType.StoredProcedure);
			return result;
        }

		public void Dispose()
		{
			connection.Dispose();
		}

        public string GetConnectionString()
        {
            return conString;
        }

    }
}
