using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class Item : IParser<int>, IParser<double> {

        private readonly EndianOps endianOps;

        public Item(EndianOps endianOps) {
            this.endianOps = endianOps;
        }

        (int, ArraySegment<byte>)? IParser<int>.Call(ArraySegment<byte> bytes) {
            throw new NotImplementedException();
        }

        (double, ArraySegment<byte>)? IParser<double>.Call(ArraySegment<byte> bytes) {
            throw new NotImplementedException();
        }
    }
}
