using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace yourmt.Sockets.Internal
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    internal class WsaWrapper
    {
        /// <summary>
        /// Initiates use of the Winsock DLL by the current process.
        /// </summary>
        /// <param name="requestedVersion">
        /// Type: <see cref="yourmt.Sockets.WinSockVersion"/>
        /// The requested <see cref="WinSockVersion"/>.
        /// </param>
        public WsaWrapper(WinSockVersion requestedVersion)
        {
            _data = new WsaData();
            Int32 res = WinSock2.WSAStartup(requestedVersion, ref _data);
            if(res != 0)
                throw new Win32Exception(res); // WSAStartup returns the error value by itself
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private WsaData _data;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public WsaData Data
        {
            get { return _data; }
        }

        /// <summary>
        /// Terminates use of the Winsock DLL by the current process.
        /// </summary>
        ~WsaWrapper()
        {
            if(WinSock2.WSACleanup() != 0)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }
    }
}
