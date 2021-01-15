using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class EndianOps : IParser<int>, IParser<double> {

        private readonly Endian endian;
        
        public EndianOps(Endian endian) {
            this.endian = endian;
        }

        (int, ArraySegment<byte>)? IParser<int>.Call(ArraySegment<byte> bytes) =>
            this.endian switch {
                Endian.Big => (BinaryPrimitives.ReadInt32BigEndian(bytes.Slice(0, 4)), bytes.Slice(4)),
                Endian.Little => (BinaryPrimitives.ReadInt32LittleEndian(bytes.Slice(0, 4)), bytes.Slice(4)),
                _ => null
            };

        (double, ArraySegment<byte>)? IParser<double>.Call(ArraySegment<byte> bytes) =>
            this.endian switch {
                Endian.Big => (BinaryPrimitives.ReadDoubleBigEndian(bytes.Slice(0, 8)), bytes.Slice(8)),
                Endian.Little => (BinaryPrimitives.ReadDoubleLittleEndian(bytes.Slice(0, 8)), bytes.Slice(8)),
                _ => null
            };
    }
}
