using System;

namespace Compass {

    public class Map<A, B> : IParser<B> {

        private readonly IParser<A> parser;
        private readonly Func<A, B> func;
        public Map(IParser<A> parser, Func<A, B> func) {
            this.parser = parser;
            this.func = func;
        }

        public (B, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            this.parser.Call(bytes) switch {
                null => null,
                (var a, var b) => (func(a), b)
            };
    }
}
