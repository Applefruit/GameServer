using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerServerUnity.Networking.Converters
{
    public static class Converter
    {
        public static byte[] Vector3ToByteArray(Vector3 input)
        {
            byte[] buff = new byte[sizeof(float) * 3];
            Buffer.BlockCopy(BitConverter.GetBytes(input.X), 0, buff, 0 * sizeof(float), sizeof(float));
            Buffer.BlockCopy(BitConverter.GetBytes(input.Y), 0, buff, 1 * sizeof(float), sizeof(float));
            Buffer.BlockCopy(BitConverter.GetBytes(input.Z), 0, buff, 2 * sizeof(float), sizeof(float));

            return buff;
        }
        public static Vector3 ByteToVector3(byte[] data)
        {
            Vector3 convertedVector = Vector3.Zero;

            convertedVector.X = BitConverter.ToSingle(data, 0 * sizeof(float));
            convertedVector.Y = BitConverter.ToSingle(data, 1 * sizeof(float));
            convertedVector.Z = BitConverter.ToSingle(data, 2 * sizeof(float));

            return convertedVector;
        }
    }
}
