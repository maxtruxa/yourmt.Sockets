using System;

namespace yourmt.Sockets.Internal
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public struct HostEnt
    {
        String h_name; // char*
        String[] h_aliases; // char**
        Int16 h_addrtype; // short
        Int16 h_length; // short
        String[] h_addr_list; // char**

        public static HostEnt FromIntPtr(IntPtr addr)
        {
            HostEnt hostent = new HostEnt();
#warning The HostEnt structure isn't working yet.
            return hostent;
        }
    }
}
