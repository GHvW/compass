using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {
    public class IntP : IParser<int> {

        private readonly Endian endian;

        public IntP(Endian endian) {
            this.endian = endian;
        }

        public (int, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            try {
                return this.endian switch {
                    Endian.Big => (BinaryPrimitives.ReadInt32BigEndian(bytes.Slice(0, 4)), bytes.Slice(4)),
                    Endian.Little => (BinaryPrimitives.ReadInt32LittleEndian(bytes.Slice(0, 4)), bytes.Slice(4)),
                    _ => null
                };
            } catch {
                return null;
            }
        }
    }
}
