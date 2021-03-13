using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class DoubleP : IParser<double> {

        private readonly Endian endian;

        public DoubleP(Endian endian) {
            this.endian = endian;
        }

        public (double, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            try {
                return this.endian switch {
                    Endian.Big => (BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(0, 8)), bytes.Slice(8)),
                    Endian.Little => (BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(0, 8)), bytes.Slice(8)),
                    _ => null
                };
            } catch {
                return null;
            }
        }
    }
}
