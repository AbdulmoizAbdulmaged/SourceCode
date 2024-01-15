using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Ping_Test
{
    class ServerInfo

    {
      public string ipAddress { get; set; }
        public string serverName { get; set; }
        public  string status { get; set; }
      public  string remarks { get; set; }

        public ServerInfo()
        {

        }

        public ServerInfo(string ipAddress1,string serverName1,string status1,string remarks1)
        {
            ipAddress = ipAddress1;
            status = status1;
            remarks = remarks1;
            serverName = serverName1;

        }

      
    }
}
