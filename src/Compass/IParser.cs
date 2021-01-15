using System;

namespace Compass {

    public interface IParser<A> {

        public (A, ArraySegment<byte>)? Call(ArraySegment<byte> bytes);
    }
}
