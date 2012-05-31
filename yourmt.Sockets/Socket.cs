using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using yourmt.Sockets.Internal;

namespace yourmt.Sockets
{
    /// <summary>
    /// Implements the Berkeley sockets interface.
    /// </summary>
    public class Socket : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Socket"/> class
        /// using the specified address family, socket type and protocol.
        /// </summary>
        /// <param name="addressFamily">
        /// Type: <see cref="yourmt.Sockets.AddressFamily"/>
        /// One of the <see cref="AddressFamily"/> values.
        /// </param>
        /// <param name="socketType">
        /// Type: <see cref="yourmt.Sockets.SocketType"/>
        /// One of the <see cref="SocketType"/> values.
        /// </param>
        /// <param name="protocolType">
        /// Type: <see cref="yourmt.Sockets.ProtocolType"/>
        /// One of the <see cref="ProtocolType"/> values.
        /// </param>
        public Socket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            Wsa.Init();
            AddressFamily = addressFamily;
            SocketType = socketType;
            ProtocolType = protocolType;
            Handle = WinSock2.socket((AddressFamilyInt)addressFamily, socketType, protocolType);
            if(Handle == WinSock2.InvalidSocket)
                throw new Win32Exception();
            IsBound = false;
            IsConnected = false;
            IsDisposed = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Socket"/> class using the specified parameters.
        /// This constructor is used for internal initialization of <see cref="Accept"/>ed sockets.
        /// </summary>
        /// <param name="thisPtr">
        /// Type: <see cref="System.IntPtr"/>
        /// TODO: Update summary.
        /// </param>
        /// <param name="isBound">
        /// Type: <see cref="System.Boolean"/>
        /// TODO: Update summary.
        /// </param>
        /// <param name="isConnected">
        /// Type: <see cref="System.Boolean"/>
        /// TODO: Update summary.
        /// </param>
        /// <param name="addressFamily">
        /// Type: <see cref="yourmt.Sockets.AddressFamily"/>
        /// TODO: Update summary.
        /// </param>
        /// <param name="socketType">
        /// Type: <see cref="yourmt.Sockets.SocketType"/>
        /// TODO: Update summary.
        /// </param>
        /// <param name="protocolType">
        /// Type: <see cref="yourmt.Sockets.ProtocolType"/>
        /// TODO: Update summary.
        /// </param>
        /// <param name="host">
        /// Type: <see cref="System.String"/>
        /// TODO: Update summary.
        /// </param>
        /// <param name="port">
        /// Type: <see cref="System.Int32"/>
        /// TODO: Update summary.
        /// </param>
        private Socket(IntPtr thisPtr,
                       Boolean isBound,
                       Boolean isConnected,
                       AddressFamily addressFamily,
                       SocketType socketType,
                       ProtocolType protocolType,
                       String host,
                       Int32 port)
        {
            Wsa.Init();
            Handle = thisPtr;
            if(Handle == WinSock2.InvalidSocket)
                throw new Win32Exception();
            IsBound = isBound;
            IsConnected = isConnected;
            AddressFamily = addressFamily;
            SocketType = socketType;
            ProtocolType = protocolType;
            IsDisposed = false;
        }

        /// <summary>
        /// Releases all resources used by the current instance of the <see cref="Socket"/> class.
        /// </summary>
        public void Close()
        {
            Dispose();
        }

        /// <summary>
        /// Disables sends and receives on the <see cref="Socket"/>.
        /// </summary>
        /// <param name="type">
        /// Type: <see cref="yourmt.Sockets.ShutdownType"/>
        /// One of the <see cref="ShutdownType"/> values that specifies the operation that will no longer be allowed.
        /// </param>
        public void Shutdown(ShutdownType type)
        {
            if(WinSock2.shutdown(Handle, type) == WinSock2.SocketError)
                throw new Win32Exception();
        }

        /// <summary>
        /// Associates the <see cref="Socket"/> with a local endpoint.
        /// The endpoint is specified by a host name and a port number.
        /// </summary>
        /// <param name="host">
        /// Type: <see cref="System.String"/>
        /// The host name of the local endpoint.
        /// </param>
        /// <param name="port">
        /// Type: <see cref="System.Int32"/>
        /// The port number of the local endpoint.
        /// </param>
        public void Bind(String host, Int32 port)
        {
            SockAddrIn sai = SockAddrIn.FromString(host, port, (AddressFamilyInt)AddressFamily);
            if(WinSock2.bind(Handle, ref sai, Marshal.SizeOf(sai)) == WinSock2.SocketError)
                throw new Win32Exception();
            IsBound = true;
        }

        /// <summary>
        /// Places the <see cref="Socket"/> in a listening state.
        /// </summary>
        /// <param name="backlog">
        /// Type: <see cref="System.Int32"/>
        /// The maximum length of the pending connections queue.
        /// </param>
        public void Listen(Int32 backlog)
        {
            if(WinSock2.listen(Handle, backlog) == WinSock2.SocketError)
                throw new Win32Exception();
        }

        /// <summary>
        /// Creates a new <see cref="Socket"/> for a newly created connection.
        /// </summary>
        /// <returns>
        /// Type: <see cref="yourmt.Sockets.Socket"/>
        /// A <see cref="Socket"/> for a newly created connection.
        /// </returns>
        public Socket Accept()
        {
            SockAddrIn sai = new SockAddrIn();
            Int32 len = Marshal.SizeOf(sai);
            IntPtr client = WinSock2.accept(Handle, ref sai, ref len);
            if(client == WinSock2.InvalidSocket)
                throw new Win32Exception();
            return new Socket(client, false, true, AddressFamily, SocketType, ProtocolType, sai.Host, sai.Port);
        }

        /// <summary>
        /// Establishes a connection to a remote host. The host is specified by a host name and a port number.
        /// </summary>
        /// <param name="host">
        /// Type: <see cref="System.String"/>
        /// The name of the remote host.
        /// </param>
        /// <param name="port">
        /// Type: <see cref="System.Int32"/>
        /// The port number of the remote host.
        /// </param>
        public void Connect(String host, Int32 port)
        {
            /*IntPtr addr = WinSock2.gethostbyname(host);
            if(addr == IntPtr.Zero)
                throw new Win32Exception();

            HostEnt hostent = HostEnt.FromIntPtr(addr);
#warning This has to be fixed. No address resolving is done yet.
             */

            SockAddrIn sai = SockAddrIn.FromString(host, port, (AddressFamilyInt)AddressFamily);
            if(WinSock2.connect(Handle, ref sai, Marshal.SizeOf(sai)) == WinSock2.SocketError)
                throw new Win32Exception();
            IsConnected = true;
        }

        /// <summary>
        /// Sets the specified <see cref="Socket"/> option to the specified value.
        /// </summary>
        /// <param name="level">
        /// Type: <see cref="yourmt.Sockets.SocketOptionLevel"/>
        /// One of the <see cref="SocketOptionLevel"/> values.
        /// </param>
        /// <param name="optname">
        /// Type: <see cref="yourmt.Sockets.SocketOptionName"/>
        /// One of the <see cref="SocketOptionName"/> values.
        /// </param>
        /// <param name="optval">
        /// Type: <see cref="System.Object"/>
        /// A <see cref="Object"/> (mostly <see cref="Boolean"/> or <see cref="Int32"/>) that contains the value of the option.
        /// </param>
        public void SetOption(SocketOptionLevel level, SocketOptionName optname, Object optval)
        {
            if(WinSock2.setsockopt(Handle, level, optname, ref optval, Marshal.SizeOf(optval)) == WinSock2.SocketError)
                throw new Win32Exception();
        }

        /// <summary>
        /// Gets the current value of the specified <see cref="Socket"/> option.
        /// </summary>
        /// <param name="level">
        /// Type: <see cref="yourmt.Sockets.SocketOptionLevel"/>
        /// One of the <see cref="SocketOptionLevel"/> values.
        /// </param>
        /// <param name="optname">
        /// Type: <see cref="yourmt.Sockets.SocketOptionName"/>
        /// One of the <see cref="SocketOptionName"/> values.
        /// </param>
        /// <param name="optval">
        /// Type: ref <see cref="System.Object"/>
        /// A reference of an <see cref="Object"/> (mostly <see cref="Boolean"/> or <see cref="Int32"/>) that receives the value of the option.
        /// </param>
        public void GetOption(SocketOptionLevel level, SocketOptionName optname, ref Object optval)
        {
            Int32 optlen = Marshal.SizeOf(optval);
            if(WinSock2.getsockopt(Handle, level, optname, ref optval, ref optlen) == WinSock2.SocketError)
                throw new Win32Exception();
        }

        /// <summary>
        /// Sends data from a buffer through the <see cref="Socket"/>.
        /// </summary>
        /// <param name="buffer">
        /// Type: <see cref="System.Byte[]"/>
        /// An <see cref="Array"/> of type <see cref="Byte"/> that contains the data to be sent.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Int32"/>
        /// The number of bytes sent.
        /// </returns>
        public Int32 Send(Byte[] buffer)
        {
            return Send(buffer, SocketFlags.None);
        }

        /// <summary>
        /// Sends data from a buffer through the <see cref="Socket"/>, using the specified <see cref="SocketFlags"/>.
        /// </summary>
        /// <param name="buffer">
        /// Type: <see cref="System.Byte[]"/>
        /// An <see cref="Array"/> of type <see cref="Byte"/> that contains the data to be sent.
        /// </param>
        /// <param name="flags">
        /// Type: <see cref="yourmt.Sockets.SocketFlags"/>
        /// A bitwise combination of the <see cref="SocketFlags"/> values.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Int32"/>
        /// The number of bytes sent.
        /// </returns>
        public Int32 Send(Byte[] buffer, SocketFlags flags)
        {
            return Send(buffer, buffer.Length, flags);
        }

        /// <summary>
        /// Sends the specified number of bytes of data from a buffer through the <see cref="Socket"/>,
        /// using the specified <see cref="SocketFlags"/>.
        /// </summary>
        /// <param name="buffer">
        /// Type: <see cref="System.Byte[]"/>
        /// An <see cref="Array"/> of type <see cref="Byte"/> that contains the data to be sent.
        /// </param>
        /// <param name="size">
        /// Type: <see cref="System.Int32"/>
        /// The number of bytes to send.
        /// </param>
        /// <param name="flags">
        /// Type: <see cref="yourmt.Sockets.SocketFlags"/>
        /// A bitwise combination of the <see cref="SocketFlags"/> values.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Int32"/>
        /// The number of bytes sent.
        /// </returns>
        public Int32 Send(Byte[] buffer, Int32 size, SocketFlags flags)
        {
            Int32 res = WinSock2.send(Handle, buffer, size, flags);
            if(res == WinSock2.SocketError) // Error
                throw new Win32Exception();

            return res; // Sent
        }

        /// <summary>
        /// Sends data from a string through the <see cref="Socket"/>.
        /// </summary>
        /// <param name="buffer">
        /// Type: <see cref="System.String"/>
        /// A <see cref="String"/> that contains the data to be sent.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Int32"/>
        /// The number of bytes sent.
        /// </returns>
        public Int32 Send(String buffer)
        {
            return Send(System.Text.Encoding.Default.GetBytes(buffer), SocketFlags.None);
        }

        /// <summary>
        /// Receives data from the <see cref="Socket"/> into a buffer.
        /// </summary>
        /// <param name="buffer">
        /// Type: <see cref="System.Byte[]"/>
        /// An <see cref="Array"/> of type <see cref="Byte"/> that is the storage location for the received data.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Int32"/>
        /// The number of bytes received.
        /// </returns>
        public Int32 Receive(Byte[] buffer)
        {
            return Receive(buffer, SocketFlags.None);
        }

        /// <summary>
        /// Receives data from the <see cref="Socket"/> into a buffer, using the specified <see cref="SocketFlags"/>.
        /// </summary>
        /// <param name="buffer">
        /// Type: <see cref="System.Byte[]"/>
        /// An <see cref="Array"/> of type <see cref="Byte"/> that is the storage location for the received data.
        /// </param>
        /// <param name="flags">
        /// Type: <see cref="yourmt.Sockets.SocketFlags"/>
        /// A bitwise combination of the <see cref="SocketFlags"/> values.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Int32"/>
        /// The number of bytes received.
        /// </returns>
        public Int32 Receive(Byte[] buffer, SocketFlags flags)
        {
            return Receive(buffer, buffer.Length, SocketFlags.None);
        }

        /// <summary>
        /// Receives the specified number of bytes of data from the <see cref="Socket"/> into a buffer,
        /// using the specified <see cref="SocketFlags"/>.
        /// </summary>
        /// <param name="buffer">
        /// Type: <see cref="System.Byte[]"/>
        /// An <see cref="Array"/> of type <see cref="Byte"/> that is the storage location for the received data.
        /// </param>
        /// <param name="size">
        /// Type: <see cref="System.Int32"/>
        /// The number of bytes to receive.
        /// </param>
        /// <param name="flags">
        /// Type: <see cref="yourmt.Sockets.SocketFlags"/>
        /// A bitwise combination of the <see cref="SocketFlags"/> values.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Int32"/>
        /// The number of bytes received.
        /// </returns>
        public Int32 Receive(Byte[] buffer, Int32 size, SocketFlags flags)
        {
            Int32 res = WinSock2.recv(Handle, buffer, size, flags);
            if(res == WinSock2.SocketError) // Error
                throw new Win32Exception();
            if(res == 0)
                IsConnected = false;
            return res; // Close / Received
        }

        /// <summary>
        /// Determines the status of one or more <see cref="Socket"/>s.
        /// </summary>
        /// <param name="read">
        /// Type: <see cref="yourmt.Sockets.FdSet"/>
        /// An <see cref="FdSet"/> to check for readability.
        /// </param>
        /// <param name="write">
        /// Type: <see cref="yourmt.Sockets.FdSet"/>
        /// An <see cref="FdSet"/> to check for writability.
        /// </param>
        /// <param name="error">
        /// Type: <see cref="yourmt.Sockets.FdSet"/>
        /// An <see cref="FdSet"/> to check for errors.
        /// </param>
        /// <param name="timeout">
        /// Type: <see cref="yourmt.Sockets.TimeInterval"/>
        /// A time-out value as <see cref="TimeInterval"/>. <b>null</b> indicates an infinite time-out.
        /// </param>
        /// <returns>
        /// Returns the total number of <see cref="Socket"/>s that are ready and contained in the <see cref="FdSet"/>s
        /// or zero if the time limit expired.
        /// </returns>
        public static Int32 Select(FdSet read, FdSet write, FdSet error, TimeInterval timeout)
        {
            IntPtr[] readFdSet = (read != null) ? read.ToNative() : FdSet.EmptyNative;
            IntPtr[] writeFdSet = (write != null) ? write.ToNative() : FdSet.EmptyNative;
            IntPtr[] errorFdSet = (error != null) ? error.ToNative() : FdSet.EmptyNative;

            Int32 res = WinSock2.select(1, readFdSet, writeFdSet, errorFdSet, ref timeout);
            if(res == WinSock2.SocketError) // Error
                throw new Win32Exception();

            if(read != null)
                read._list = FdSet.FromNative(readFdSet);
            if(write != null)
                write._list = FdSet.FromNative(writeFdSet);
            if(error != null)
                error._list = FdSet.FromNative(errorFdSet);

            return res;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        internal IntPtr Handle { get; private set; }

        /// <summary>
        /// Gets the address family of the <see cref="Socket"/>.
        /// </summary>
        public AddressFamily AddressFamily { get; private set; }

        /// <summary>
        /// Gets the type of the <see cref="Socket"/>.
        /// </summary>
        public SocketType SocketType { get; private set; }

        /// <summary>
        /// Gets the protocol type of the <see cref="Socket"/>.
        /// </summary>
        public ProtocolType ProtocolType { get; private set; }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="Socket"/> is bound to a specific local port.
        /// </summary>
        public Boolean IsBound { get; private set; }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="Socket"/> is connected to a remote host as of
        /// the last <see cref="Send"/> or <see cref="Receive"/> operation.
        /// </summary>
        public Boolean IsConnected { get; private set; }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="Socket"/> is disposed.
        /// </summary>
        public Boolean IsDisposed { get; private set; }

        /// <summary>
        /// Releases all resources used by the current instance of the <see cref="Socket"/> class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <param name="disposing">
        /// Type: <see cref="System.Boolean"/>
        /// TODO: Update summary.
        /// </param>
        private void Dispose(Boolean disposing)
        {
            if(disposing) { }

            if(Handle != WinSock2.InvalidSocket)
            {
                WinSock2.closesocket(Handle);
                Handle = WinSock2.InvalidSocket;
            }

            IsDisposed = true;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        ~Socket()
        {
            Dispose(false);
        }
    }
}
