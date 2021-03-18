using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {
    public class IntBytes : IParser<ArraySegment<byte>> {

        public IntBytes() { }

        //public (int, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
        //    try {
        //        return this.endian switch {
        //            Endian.Big => (BinaryPrimitives.ReadInt32BigEndian(bytes.Slice(0, 4)), bytes.Slice(4)),
        //            Endian.Little => (BinaryPrimitives.ReadInt32LittleEndian(bytes.Slice(0, 4)), bytes.Slice(4)),
        //            _ => null
        //        };
        //    } catch {
        //        return null;
        //    }
        //}

        public (ArraySegment<byte>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            try {
                return (bytes.Slice(0, 4), bytes.Slice(4));
            } catch {
                return null;
            }
        }
    }
}
