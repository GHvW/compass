using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class BindWithSelector<A, B, C> : IParser<C> {

        private readonly IParser<A> parser;
        private readonly Func<A, IParser<B>> func;
        private readonly Func<A, B, C> selector;

        public BindWithSelector(
            IParser<A> parser, 
            Func<A, IParser<B>> func, 
            Func<A, B, C> selector) {

            this.parser = parser;
            this.func = func;
            this.selector = selector;
        }

        public (C, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            this.parser.Call(bytes) switch {
                null => null,
                (var a, var rest) => func(a).Call(rest) switch {
                    null => null,
                    (var b, var leftover) => new Return<C>(this.selector(a, b)).Call(leftover)
                }
            };
    }
}
