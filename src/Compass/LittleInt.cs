using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class LittleInt : IParser<int> {

        public LittleInt() { }

        public (int, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            return new IntBytes()
                .Select(intBytes => BinaryPrimitives.ReadInt32LittleEndian(intBytes))
                .Call(bytes);
        }
    }
}
