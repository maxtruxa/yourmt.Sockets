using System;

namespace yourmt.Sockets
{
    /// <summary>
    /// Specifies the protocols that the <see cref="Socket"/> class supports.
    /// </summary>
    public enum ProtocolType : int
    {
        /// <summary>
        /// Internet Control Message Protocol.
        /// </summary>
        Icmp = 0x00000001,

        /// <summary>
        /// Internet Group Management Protocol.
        /// </summary>
        Igmp = 0x00000002,

        /// <summary>
        /// Bluetooth Radio Frequency Communications Protocol.
        /// </summary>
        RfComm = 0x00000003,

        /// <summary>
        /// Transmission Control Protocol.
        /// </summary>
        Tcp = 0x00000006,

        /// <summary>
        /// User Datagram Protocol.
        /// </summary>
        Udp = 0x00000011,

        /// <summary>
        /// Internet Control Message Protocol for IPv6.
        /// </summary>
        IcmpV6 = 0x0000003A,

        /// <summary>
        /// PGM Protocol.
        /// </summary>
        Rm = 0x00000071,
    }
}
