using System;

namespace yourmt.Sockets
{
    /// <summary>
    /// Specifies the type of socket that an instance of the <see cref="Socket"/> class represents.
    /// </summary>
    public enum SocketType : int
    {
        /// <summary>
        /// Supports reliable, two-way, connection-based byte streams without the duplication of data and without
        /// preservation of boundaries. A <see cref="Socket"/> of this type communicates with a single peer and
        /// requires a remote host connection before communication can begin. <b>Stream</b> uses the Transmission
        /// Control Protocol (<b>Tcp</b>) <see cref="ProtocolType"/> and the <b>Inet</b>/<b>Inet6</b> <see cref="AddressFamily"/>.
        /// </summary>
        Stream = 0x00000001,
        
        /// <summary>
        /// Supports datagrams, which are connectionless, unreliable messages of a fixed (typically small) maximum length.
        /// Messages might be lost or duplicated and might arrive out of order. A <see cref="Socket"/> of type <b>Dgram</b>
        /// requires no connection prior to sending and receiving data, and can communicate with multiple peers. <b>Dgram</b>
        /// uses the Datagram Protocol (<b>Udp</b>) <see cref="ProtocolType"/> and the <b>InterNetwork</b> <see cref="AddressFamily"/>.
        /// </summary>
        Dgram = 0x00000002,
        
        /// <summary>
        /// Supports access to the underlying transport protocol. Using the <see cref="SocketType"/> <b>Raw</b>, you can
        /// communicate using protocols like Internet Control Message Protocol (<b>Icmp</b>) and Internet Group Management
        /// Protocol (<b>Igmp</b>). Your application must provide a complete IP header when sending. Received datagrams
        /// return with the IP header and options intact.
        /// </summary>
        Raw = 0x00000003,
        
        /// <summary>
        /// Supports connectionless, message-oriented, reliably delivered messages, and preserves message boundaries in
        /// data. <b>Rdm</b> (Reliably Delivered Messages) messages arrive unduplicated and in order. Furthermore, the
        /// sender is notified if messages are lost. If you initialize a <see cref="Socket"/> using Rdm, you do not require
        /// a remote host connection before sending and receiving data. With Rdm, you can communicate with multiple peers.
        /// </summary>
        Rdm = 0x00000004,

        /// <summary>
        /// Provides connection-oriented and reliable two-way transfer of ordered byte streams across a network. <b>SeqPacket</b>
        /// does not duplicate data, and it preserves boundaries within the data stream. A <see cref="Socket"/> of type SeqPacket
        /// communicates with a single peer and requires a remote host connection before communication can begin.
        /// </summary>
        SeqPacket = 0x00000005,
    }
}
