using System;
using System.Buffers.Binary;

namespace Compass {

    public class BigInt : IParser<int> {

        public BigInt() { }

        public (int, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            return new IntBytes()
                .Select(intBytes => BinaryPrimitives.ReadInt32BigEndian(intBytes))
                .Call(bytes);
        }
    }
}
