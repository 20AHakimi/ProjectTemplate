using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.NetTools
{
    public class NetInfo
    {
        public static List<IPAddress> GetIPAddresses()
        {
            List<IPAddress> _return = new();
            foreach (NetworkInterface _ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                IPInterfaceProperties _ipProps = _ni.GetIPProperties();

                foreach (UnicastIPAddressInformation _ip in _ipProps.UnicastAddresses)
                {
                    _return.Add(_ip.Address);
                }
            }

            return _return;
        }
    }
}
