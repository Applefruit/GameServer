using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerServerUnity.Networking.Send_ReceiveEnums
{
    public enum PackageHandlerEnum
    {
        DebugMessage = 1,
        TransformPacket = 400,
        LoginPacket = 1200,
    }

    public enum PackageSenderEnum
    {
        ReturnPackage = 1201,
    }
}