using System;

namespace yourmt.Sockets.Internal
{
    /// <summary>
    /// Specifies the addressing scheme that an instance of the <see cref="Socket"/> class can use.
    /// This <see cref="Enum"/> answers internal purposes.
    /// </summary>
    internal enum AddressFamilyInt : int
    {
        /// <summary>
        /// Unspecified address family.
        /// </summary>
        Unspec = 0x00000000,

        /// <summary>
        /// Address for IP version 4.
        /// </summary>
        Inet = 0x00000002,

        /// <summary>
        /// IPX or SPX address.
        /// </summary>
        Ipx = 0x00000006,

        /// <summary>
        /// AppleTalk address.
        /// </summary>
        AppleTalk = 0x00000010,

        /// <summary>
        /// NetBios address.
        /// </summary>
        NetBios = 0x00000011,

        /// <summary>
        /// Address for IP version 6.
        /// </summary>
        Inet6 = 0x00000017,

        /// <summary>
        /// IrDA address.
        /// </summary>
        Irda = 0x0000001A,

        /// <summary>
        /// Bluetooth address.
        /// </summary>
        Bth = 0x00000020,
    }
}
