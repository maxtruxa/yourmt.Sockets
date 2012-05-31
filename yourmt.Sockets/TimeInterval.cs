using System;
using System.Runtime.InteropServices;

namespace yourmt.Sockets
{
    /// <summary>
    /// Represents a timeinterval in seconds and microseconds.
    /// </summary>
    /// <remarks>
    /// Used in <see cref="Socket.Select"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TimeInterval
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeInterval"/> class using the given values.
        /// </summary>
        /// <param name="sec">
        /// Type: <see cref="System.Int32"/>
        /// A timeinterval, in seconds.
        /// </param>
        /// <param name="usec">
        /// Type: <see cref="System.Int32"/>
        /// A timeinterval, in microseconds.
        /// </param>
        public TimeInterval(Int32 sec, Int32 usec)
        {
            tv_sec = sec;
            tv_usec = usec;
        }

        /// <summary>
        /// Time interval, in seconds.
        /// </summary>
        public Int32 tv_sec;

        /// <summary>
        /// Time interval, in microseconds.
        /// </summary>
        public Int32 tv_usec;
    }
}
