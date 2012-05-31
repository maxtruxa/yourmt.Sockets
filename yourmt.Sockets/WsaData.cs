using System;
using System.Runtime.InteropServices;

namespace yourmt.Sockets
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct WsaData
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public WinSockVersion wVersion;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public UInt16 wHighVersion;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
        public String szDescription;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public String szSystemStatus;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public UInt16 iMaxSockets;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public UInt16 iMaxUdpDg;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public IntPtr lpVendorInfo;
    }
}
