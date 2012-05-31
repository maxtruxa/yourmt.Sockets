using System;

namespace yourmt.Sockets
{
    /// <summary>
    /// Defines the various types of shutdown the <see cref="Socket.Shutdown"/> method supports.
    /// </summary>
    public enum ShutdownType : int
    {
        /// <summary>
        /// Disables a <see cref="Socket"/> for receiving.
        /// </summary>
        Receive = 0x0,
        /// <summary>
        /// Disables a <see cref="Socket"/> for sending.
        /// </summary>
        Send = 0x1,
        /// <summary>
        /// Disables a <see cref="Socket"/> for both sending and receiving.
        /// </summary>
        Both = 0x2,
    }
}
