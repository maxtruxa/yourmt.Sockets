using System;
using System.Collections.Generic;

namespace yourmt.Sockets
{
    /// <summary>
    /// Represents a set of <see cref="Socket"/>s.
    /// </summary>
    public class FdSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FdSet"/> class that is empty.
        /// </summary>
        public FdSet()
        {
            _list = new List<IntPtr>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FdSet"/> class that contains the specified <see cref="Socket"/>.
        /// </summary>
        /// <param name="socket">
        /// Type: <see cref="yourmt.Sockets.Socket"/>
        /// The <see cref="Socket"/> which is copied to the new <see cref="FdSet"/>.
        /// </param>
        public FdSet(Socket socket)
        {
            _list = new List<IntPtr>();
            _list.Add(socket.Handle);
        }

        /// <summary>
        /// Removes all <see cref="Socket"/>s from the <see cref="FdSet"/>.
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Adds a <see cref="Socket"/> to the <see cref="FdSet"/>.
        /// </summary>
        /// <param name="socket">
        /// Type: <see cref="yourmt.Sockets.Socket"/>
        /// The <see cref="Socket"/> to be added to the <see cref="FdSet"/>.
        /// </param>
        public void Add(Socket socket)
        {
            _list.Add(socket.Handle);
        }

        /// <summary>
        /// Adds the <see cref="Socket"/>s of the specified collection to the <see cref="FdSet"/>.
        /// </summary>
        /// <param name="sockets">
        /// Type: <see cref="System.Collections.Generic.IEnumerable<Socket>"/>
        /// The collection whose <see cref="Socket"/> elements should be added to the <see cref="FdSet"/>.
        /// </param>
        public void Add(IEnumerable<Socket> sockets)
        {
            foreach(Socket socket in sockets)
                _list.Add(socket.Handle);
        }

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="Socket"/> from the <see cref="FdSet"/>.
        /// </summary>
        /// <param name="socket">
        /// Type: <see cref="yourmt.Sockets.Socket"/>
        /// The <see cref="Socket"/> to remove from the <see cref="FdSet"/>.
        /// </param>
        public void Remove(Socket socket)
        {
            _list.Remove(socket.Handle);
        }

        /// <summary>
        /// Determines whether a <see cref="Socket"/> is in the <see cref="FdSet"/>.
        /// </summary>
        /// <param name="socket">
        /// Type: <see cref="yourmt.Sockets.Socket"/>
        /// The <see cref="Socket"/> to locate in the <see cref="FdSet"/>.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <b>true</b> if <paramref name="socket"/> is found in the <see cref="FdSet"/>; otherwise, <b>false</b>.
        /// </returns>
        public Boolean Contains(Socket socket)
        {
            if(_list.Contains(socket.Handle))
                return true;

            return false;
        }

        /// <summary>
        /// Gets or sets the internal <see cref="List<T>"/> of native <see cref="SOCKET"/>s (as <see cref="IntPtr"/>s).
        /// </summary>
        internal List<IntPtr> _list { get; set; }

        /// <summary>
        /// Converts the internal <see cref="List<T>"/> of <b>SOCKET</b>s to a native <b>fd_set</b>.
        /// </summary>
        /// <returns>
        /// Type: <see cref="System.IntPtr[]"/>
        /// A native <b>fd_set</b> represented by an <see cref="Array"/> of type <see cref="IntPtr"/>.
        /// </returns>
        internal IntPtr[] ToNative()
        {
            IntPtr[] native = new IntPtr[_list.Count + 1];

            native[0] = (IntPtr)_list.Count;
            for(Int32 i = 0; i < _list.Count; i++)
                native[i + 1] = _list[i];

            return native;
        }

        /// <summary>
        /// Converts a native <b>fd_set</b> to a <see cref="List<T>"/> of <see cref="IntPtr"/>s.
        /// </summary>
        /// <param name="native">
        /// Type: <see cref="System.IntPtr[]"/>
        /// An <see cref="Array"/> of type <see cref="IntPtr"/> that represents a native <b>fd_set</b>.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Collections.Generic.List<System.IntPtr>"/>
        /// A <see cref="List<T>"/> containing the native <b>SOCKET</b>s (as <see cref="IntPtr"/>s).
        /// </returns>
        internal static List<IntPtr> FromNative(IntPtr[] native)
        {
            List<IntPtr> list = new List<IntPtr>();

            for(Int32 i = 0; i < (Int32)native[0]; i++)
                list.Add(native[i + 1]);

            return list;
        }

        /// <summary>
        /// Represents an empty native <b>fd_set</b>.
        /// </summary>
        internal static IntPtr[] EmptyNative
        {
            get
            {
                return new IntPtr[1] { IntPtr.Zero };
            }
        }
    }
}
