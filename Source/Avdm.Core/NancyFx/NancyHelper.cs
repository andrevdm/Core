﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Avdm.Core.NancyFx
{
    public static class NancyHelper
    {
        public static Uri[] GetUriParams( int port )
        {
            var uriParams = new List<Uri>();
            string hostName = Dns.GetHostName();

            // Host name URI
            string hostNameUri = string.Format( "http://{0}:{1}", Dns.GetHostName(), port );
            uriParams.Add( new Uri( hostNameUri ) );

            // Host address URI(s)
            var hostEntry = Dns.GetHostEntry( hostName );
            foreach( var ipAddress in hostEntry.AddressList )
            {
                if( ipAddress.AddressFamily == AddressFamily.InterNetwork )  // IPv4 addresses only
                {
                    var addrBytes = ipAddress.GetAddressBytes();
                    string hostAddressUri = string.Format( "http://{0}.{1}.{2}.{3}:{4}", addrBytes[0], addrBytes[1], addrBytes[2], addrBytes[3], port );
                    uriParams.Add( new Uri( hostAddressUri ) );
                }
            }

            // Localhost URI
            uriParams.Add( new Uri( string.Format( "http://localhost:{0}", port ) ) );
            return uriParams.ToArray();
        }
    }
}
