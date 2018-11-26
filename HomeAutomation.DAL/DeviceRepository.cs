using HomeAutomation.Common.Entity;
using HomeAutomation.Common.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.DAL
{
    public class DeviceRepository
    {
        private string connectionString = string.Empty;
        private SqlDataAccess dataAceess = null;

        public DeviceRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["HomeAutomation"].ConnectionString;
            this.dataAceess = new SqlDataAccess(connectionString);
        }

        public bool UpdatePublicIp(Device device)
        {
            DalParameterList parameters = new DalParameterList();
            parameters.Add(new DalParameter { ParameterName = "@MacId", ParameterValue = device.MacId, ParameterType = SqlDbType.VarChar });
            parameters.Add(new DalParameter { ParameterName = "@IPAddress", ParameterValue = device.IPAddress, ParameterType = SqlDbType.VarChar });

            var result = dataAceess.ExecuteNonQuery("UpdateDeviceIP", CommandType.StoredProcedure, parameters);

            return result > 0;
        }

        public Device GetDeviceInfo(string MacId)
        {
            DalParameterList parameters = new DalParameterList();
            parameters.Add(new DalParameter { ParameterName = "@MacId", ParameterValue = MacId, ParameterType = SqlDbType.VarChar });
            
            var result = dataAceess.GetScalar("GetDeviceInfoByMacId", CommandType.StoredProcedure, parameters);

            return new Device { IPAddress = result.ToString(), MacId = MacId };
        }
    }
}
