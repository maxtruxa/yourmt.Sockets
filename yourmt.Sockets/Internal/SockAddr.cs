using System;
using System.Runtime.InteropServices;

namespace yourmt.Sockets.Internal
{
    /// <summary>
    /// TODO: Update summary.
    /// This struct answers internal purposes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct SockAddr
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public AddressFamily sa_family;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public String sa_data;
    }
}
