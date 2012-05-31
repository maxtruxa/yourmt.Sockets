using System;
using System.Runtime.InteropServices;

namespace yourmt.Sockets.Internal
{
    /// <summary>
    /// Imports function from the Winsock DLL ("ws2_32.dll").
    /// This class answers internal purposes.
    /// </summary>
    internal class WinSock2
    {
        [DllImport("ws2_32.dll")]
        public static extern Int32 WSAStartup(WinSockVersion wVersionRequested, ref WsaData wsaData);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 WSACleanup();

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern IntPtr socket(AddressFamilyInt af, SocketType type, ProtocolType protocol);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 closesocket(IntPtr s);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 shutdown(IntPtr s, ShutdownType how);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 bind(IntPtr s, ref SockAddrIn name, Int32 namelen);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 listen(IntPtr s, Int32 backlog);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern IntPtr accept(IntPtr s, ref SockAddrIn addr, ref Int32 addrlen);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 connect(IntPtr s, ref SockAddrIn name, Int32 namelen);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 setsockopt(IntPtr s, SocketOptionLevel level, SocketOptionName optname,
            ref Object optval, Int32 optlen);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 getsockopt(IntPtr s, SocketOptionLevel level, SocketOptionName optname,
            ref Object optval, ref Int32 optlen);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 send(IntPtr s, [MarshalAs(UnmanagedType.LPArray)] Byte[] buf, Int32 len, SocketFlags flags);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 recv(IntPtr s, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Byte[] buf,
            Int32 len, SocketFlags flags);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 select(Int32 nfds, IntPtr[] readfds, IntPtr[] writefds, IntPtr[] exceptfds,
            ref TimeInterval timeout);

        [DllImport("ws2_32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "WSAAddressToStringW")]
        public static extern Int32 WSAAddressToString(ref SockAddrIn lpsaAddress, UInt32 dwAddressLength,
            IntPtr lpProtocolInfo, System.Text.StringBuilder lpszAddressString, ref UInt32 lpdwAddressStringLength);

        [DllImport("ws2_32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "WSAStringToAddressW")]
        public static extern Int32 WSAStringToAddress(String AddressString, AddressFamilyInt AddressFamily,
            IntPtr lpProtocolInfo, ref SockAddrIn pAddr, ref Int32 lpAddressLength);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 WSANtohs(IntPtr s, UInt16 netshort, ref UInt16 lphostshort);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern Int32 WSAHtons(IntPtr s, UInt16 hostshort, ref UInt16 lpnetshort);

        /*[DllImport("ws2_32.dll", CharSet = CharSet.Auto)]
        public static extern UInt32 inet_addr(String cp);

        [DllImport("ws2_32.dll", CharSet = CharSet.Auto)]
        public static extern String inet_ntoa(InAddr inAddr);

        [DllImport("ws2_32.dll")]
        public static extern UInt16 htons(UInt16 hostshort);

        [DllImport("ws2_32.dll")]
        public static extern UInt16 ntohs(UInt16 netshort);*/

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern IntPtr gethostbyname(String name);

        /// <summary>
        /// The value that indicates an invalid socket.
        /// </summary>
        public static IntPtr InvalidSocket = new IntPtr(-1);

        /// <summary>
        /// The value that indicates that a socket operation failed.
        /// </summary>
        public static Int32 SocketError = -1;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static UInt32 InAddrNone = 0xFFFFFFFF;
    }
}
