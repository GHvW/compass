using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    class DoubleBytes : IParser<ArraySegment<byte>> {

        public DoubleBytes() { }

        public (ArraySegment<byte>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            try {
                return (bytes.Slice(0, 8), bytes.Slice(8));
            } catch {
                return null;
            }
        }
    }
}
