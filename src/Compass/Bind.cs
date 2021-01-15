using System;

namespace Compass {
    public class Bind<A, B> : IParser<B> {

        private readonly IParser<A> parser;
        private readonly Func<A, IParser<B>> func;

        public Bind(IParser<A> parser, Func<A, IParser<B>> func) {
            this.parser = parser;
            this.func = func;
        }

        public (B, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            this.parser.Call(bytes) switch {
                null => null,
                (var a, var b) => func(a).Call(b)
            };

    }
}
