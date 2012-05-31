using System;

namespace yourmt.Sockets
{
    /// <summary>
    /// Specifies the addressing scheme that an instance of the <see cref="Socket"/> class can use.
    /// </summary>
    public enum AddressFamily : short
    {
        /// <summary>
        /// Unspecified address family.
        /// </summary>
        Unspec = 0x0000,

        /// <summary>
        /// Address for IP version 4.
        /// </summary>
        Inet = 0x0002,

        /// <summary>
        /// IPX or SPX address.
        /// </summary>
        Ipx = 0x0006,

        /// <summary>
        /// AppleTalk address.
        /// </summary>
        AppleTalk = 0x0010,

        /// <summary>
        /// NetBios address.
        /// </summary>
        NetBios = 0x0011,

        /// <summary>
        /// Address for IP version 6.
        /// </summary>
        Inet6 = 0x0017,

        /// <summary>
        /// IrDA address.
        /// </summary>
        Irda = 0x001A,

        /// <summary>
        /// Bluetooth address.
        /// </summary>
        Bth = 0x0020,
    }
}
