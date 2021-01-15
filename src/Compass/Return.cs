using System;

namespace Compass {
    public class Return<A> : IParser<A> {

        private readonly A item;

        public Return(A item) {
            this.item = item;
        }

        public (A, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            (this.item, bytes);
    }
}
