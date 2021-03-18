using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class LittleDouble : IParser<double> {

        public LittleDouble() { }

        public (double, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            return new DoubleBytes()
                .Select(doubleBytes => BinaryPrimitives.ReadDoubleLittleEndian(doubleBytes))
                .Call(bytes);
        }
    }
}
