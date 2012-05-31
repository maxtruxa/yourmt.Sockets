using System;

namespace yourmt.Sockets
{
    /// <summary>
    /// Defines socket option levels for the <see cref="Socket.GetOption"/> and <see cref="Socket.GetOption"/> methods.
    /// </summary>
    public enum SocketOptionLevel : int
    {
        /// <summary>
        /// <see cref="Socket"/> options apply only to IP sockets.
        /// </summary>
        IP = 0x00000000,

        /// <summary>
        /// <see cref="Socket"/> options apply only to IPv6 sockets.
        /// </summary>
        IPv6 = 0x00000029,

        /// <summary>
        /// <see cref="Socket"/> options apply to all sockets.
        /// </summary>
        Socket = 0x0000FFFF,

        /// <summary>
        /// <see cref="Socket"/> options apply only to TCP sockets.
        /// </summary>
        Tcp = 0x00000006,

        /// <summary>
        /// <see cref="Socket"/> options apply only to UDP sockets.
        /// </summary>
        Udp = 0x00000011,
    }
}
