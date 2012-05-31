using System;

namespace yourmt.Sockets
{
    /// <summary>
    /// Defines various verion numbers of the Winsock DLL.
    /// </summary>
    public enum WinSockVersion : short
    {
        /// <summary>
        /// Version 1.0
        /// </summary>
        _1_0 = 0x0100,

        /// <summary>
        /// Version 1.1
        /// </summary>
        _1_1 = 0x0101,

        /// <summary>
        /// Version 2.0
        /// </summary>
        _2_0 = 0x0200,

        /// <summary>
        /// Version 2.1
        /// </summary>
        _2_1 = 0x0201,

        /// <summary>
        /// Version 2.2
        /// </summary>
        _2_2 = 0x0202,
    }
}
