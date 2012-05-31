using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using yourmt.Sockets.Internal;

namespace yourmt.Sockets
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class Wsa
    {
        /// <summary>
        /// Initiates use of the Winsock DLL by the current process.
        /// </summary>
        static Wsa()
        {
            WsaWrapper wrapper = new WsaWrapper(WinSockVersion._2_2);
            Data = wrapper.Data;
        }

        /// <summary>
        /// Initiates use of the Winsock DLL by the current process.
        /// </summary>
        public static void Init()
        {
            // Do nothing.
            // The only purpose this method has, is to cause the CLR to call the
            // static constructor, when the class is accessed the first time.
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static WsaData Data { get; private set; }
    }
}
