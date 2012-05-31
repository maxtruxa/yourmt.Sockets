using System;

namespace yourmt.Sockets
{
    /// <summary>
    /// Defines configuration option names.
    /// </summary>
    public enum SocketOptionName : int
    {
        AcceptConnection = 0x00000002,
        AddMembership = 0x0000000C,
        AddSourceMembership = 0x0000000F,
        BlockSource = 0x00000011,
        Broadcast = 0x00000020,
        BsdUrgent = 0x00000002,
        ChecksumCoverage = 0x00000014,
        Debug = 0x00000001,
        DontFragment = 0x0000000E,
        DontLinger = -0x00000081,
        DontRoute = 0x00000010,
        DropMembership = 0x0000000D,
        DropSourceMembership = 0x00000010,
        Error = 0x00001007,
        ExclusiveAddressUse = -0x00000005,
        Expedited = 0x00000002,
        HeaderIncluded = 0x00000002,
        HopLimit = 0x00000015,
        IPOptions = 0x00000001,
        IPProtectionLevel = 0x00000017,
        IpTimeToLive = 0x00000004,
        IPv6Only = 0x0000001B,
        KeepAlive = 0x00000008,
        Linger = 0x00000080,
        MaxConnections = 0x7FFFFFFF,
        MulticastInterface = 0x00000009,
        MulticastLoopback = 0x0000000B,
        MulticastTimeToLive = 0x0000000A,
        NoChecksum = 0x00000001,
        NoDelay = 0x00000001,
        OutOfBandInline = 0x00000100,
        PacketInformation = 0x00000013,
        ReceiveBuffer = 0x00001002,
        ReceiveLowWater = 0x00001004,
        ReceiveTimeout = 0x00001006,
        ReuseAddress = 0x00000004,
        SendBuffer = 0x00001001,
        SendLowWater = 0x00001003,
        SendTimeout = 0x00001005,
        Type = 0x00001008,
        TypeOfService = 0x00000003,
        UnblockSource = 0x00000012,
        UpdateAcceptContext = 0x0000700B,
        UpdateConnectContext = 0x00007010,
        UseLoopback = 0x00000040,
    }
}
