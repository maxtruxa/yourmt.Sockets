using System;

namespace yourmt.Sockets
{
    /// <summary>
    /// Specifies <see cref="Socket"/> send and receive behaviors.
    /// This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.
    /// </summary>
    [Flags()]
    public enum SocketFlags : int
    {
        /// <summary>
        /// No flags.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Process out-of-band data.
        /// </summary>
        OOB = 0x00000001,

        /// <summary>
        /// Peek at the incoming data. The data is copied into the buffer,
        /// but is not removed from the input queue.
        /// </summary>
        Peek = 0x00000002,

        /// <summary>
        /// Send without using routing tables.
        /// </summary>
        DontRoute = 0x00000004,

        /// <summary>
        /// The receive request will complete only when one of the following events occurs:
        /// - The buffer supplied by the caller is completely full.
        /// - The connection has been closed.
        /// - The request has been canceled or an error occurred.
        /// </summary>
        WaitAll = 0x00000008,
    }
}
