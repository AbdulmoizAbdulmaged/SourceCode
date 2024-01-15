using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Ping_Test
{
   public class Server1
    {
        
            public string serverIp;
            public string serverName;

            public Server1(string srvIp, string srvName)
            {
                serverIp = srvIp;
                serverName = srvName;
            }

            public string getserverIP
            {
                get
                {
                    return serverIp;
                }
                set
                {
                    // You can add validation or other logic here before setting the value
                    serverIp = value;
                }
            }
        
    }
}
