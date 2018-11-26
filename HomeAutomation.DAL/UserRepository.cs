using HomeAutomation.Common.Entity;
using HomeAutomation.Common.Helper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HomeAutomation.DAL
{
    public class UserRepository
    {
        private string connectionString = string.Empty;
        private SqlDataAccess dataAceess = null;

        public UserRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["HomeAutomation"].ConnectionString;
            this.dataAceess = new SqlDataAccess(connectionString);
        }

        public bool RegisterUser(Consumer consumer)
        {

            DalParameterList parameters = new DalParameterList();
            parameters.Add(new DalParameter { ParameterName = "@FirstName", ParameterValue = consumer.FirstName, ParameterType = SqlDbType.VarChar });
            parameters.Add(new DalParameter { ParameterName = "@LastName", ParameterValue = consumer.LastName, ParameterType = SqlDbType.VarChar });
            parameters.Add(new DalParameter { ParameterName = "@Username", ParameterValue = consumer.UserName, ParameterType = SqlDbType.VarChar });
            parameters.Add(new DalParameter { ParameterName = "@Password", ParameterValue = consumer.Password, ParameterType = SqlDbType.VarChar });
            parameters.Add(new DalParameter { ParameterName = "@MacId", ParameterValue = consumer.MacId, ParameterType = SqlDbType.VarChar });

            var result = dataAceess.ExecuteNonQuery("AddUserAndDevice", CommandType.StoredProcedure, parameters);

            return result > 0;
        }

        public List<Device> Authenticate(Authentication authInfo)
        {

            DalParameterList parameters = new DalParameterList();
            parameters.Add(new DalParameter { ParameterName = "@Username", ParameterValue = authInfo.Username, ParameterType = SqlDbType.VarChar });
            parameters.Add(new DalParameter { ParameterName = "@Password", ParameterValue = authInfo.Password, ParameterType = SqlDbType.VarChar });

            var datatable = dataAceess.GetDataTable("AuthenticateUser", CommandType.StoredProcedure, parameters);

            var result  = new List<Device>();
            result = (from DataRow dr in datatable.Rows
                           select new Device()
                           {
                               MacId = dr["MacId"].ToString(),
                               IPAddress = dr["IPAddress"].ToString()
                           }).ToList();
            return result;
        }
    }
}
