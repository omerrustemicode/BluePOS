using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace TestProject.myclass
{
     public class savedb
    {
        Configuration config;
        public savedb()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        }
        public string getconnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }
        public void saveconn(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "MySql.Data.MySqlClient";
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
