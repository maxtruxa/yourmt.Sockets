using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace yourmt.Sockets.Internal
{
    /// <summary>
    /// TODO: Update summary.
    /// This struct answers internal purposes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct SockAddrIn
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public AddressFamily sin_family;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public UInt16 sin_port;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public InAddr sin_addr;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Byte[] sin_zero;


        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public String Host
        {
            get
            {
                SockAddrIn local = this;
                UInt32 length = 0x100;
                StringBuilder builder = new StringBuilder((Int32)length);

                Wsa.Init();
                if(WinSock2.WSAAddressToString(ref local, (UInt32)Marshal.SizeOf(local),
                    IntPtr.Zero, builder, ref length) == WinSock2.SocketError)
                {
                    throw new Win32Exception();
                }

                return builder.ToString().Split(':')[0];
            }
        }


        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public Int32 Port
        {
            get
            {
                SockAddrIn local = this;
                UInt32 length = 0x100;
                StringBuilder builder = new StringBuilder((Int32)length);

                Wsa.Init();
                if(WinSock2.WSAAddressToString(ref local, (UInt32)Marshal.SizeOf(local),
                    IntPtr.Zero, builder, ref length) == WinSock2.SocketError)
                {
                    throw new Win32Exception();
                }

                return Int32.Parse(builder.ToString().Split(':')[1]);
            }
        }


        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static SockAddrIn FromString(String host, Int32 port, AddressFamilyInt addressFamily)
        {
            SockAddrIn sockaddr = new SockAddrIn();
            Int32 lpAddressLength = Marshal.SizeOf(sockaddr);

            Wsa.Init();
            if(WinSock2.WSAStringToAddress(host + ":" + port, addressFamily,
                IntPtr.Zero, ref sockaddr, ref lpAddressLength) == WinSock2.SocketError)
            {
                throw new Win32Exception();
            }

            return sockaddr;
        }
    }
}
