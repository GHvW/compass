using System;

namespace Compass {

    public class Zero<A> : IParser<A> {

        public Zero() { }

        public (A, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) => null;

    }
}
