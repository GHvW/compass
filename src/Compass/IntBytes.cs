using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {
    public class IntBytes : IParser<ArraySegment<byte>> {

        public IntBytes() { }

        public (ArraySegment<byte>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            try {
                return (bytes.Slice(0, 4), bytes.Slice(4));
            } catch {
                return null;
            }
        }
    }
}
