using System;
using System.Runtime.InteropServices;

namespace yourmt.Sockets.Internal
{
    /// <summary>
    /// TODO: Update summary.
    /// This struct answers internal purposes.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    internal struct InAddr
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        [FieldOffset(0)]
        public Byte s_b1;
        [FieldOffset(1)]
        public Byte s_b2;
        [FieldOffset(2)]
        public Byte s_b3;
        [FieldOffset(3)]
        public Byte s_b4;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        [FieldOffset(0)]
        public UInt16 s_w1;
        [FieldOffset(2)]
        public UInt16 s_w2;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        [FieldOffset(0)]
        public UInt32 S_addr;

        /// <summary>
        /// Can be used for most TCP & IP code.
        /// </summary>
        public UInt32 s_addr
        {
            get { return S_addr; }
        }

        /// <summary>
        /// Host on imp.
        /// </summary>
        public Byte s_host
        {
            get { return s_b2; }
        }

        /// <summary>
        /// Network.
        /// </summary>
        public Byte s_net
        {
            get { return s_b1; }
        }

        /// <summary>
        /// Imp.
        /// </summary>
        public UInt16 s_imp
        {
            get { return s_w2; }
        }

        /// <summary>
        /// Imp #.
        /// </summary>
        public Byte s_impno
        {
            get { return s_b4; }
        }

        /// <summary>
        /// Logical host.
        /// </summary>
        public Byte s_lh
        {
            get { return s_b3; }
        }
    }
}
