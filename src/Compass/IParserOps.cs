using System;

namespace Compass {

    public static class ParserOps {

        public static Map<A, B> Select<A, B>(this IParser<A> parser, Func<A, B> func) =>
            new Map<A, B>(parser, func);

        public static Bind<A, B> SelectMany<A, B>(this IParser<A> parser, Func<A, IParser<B>> func) =>
            new Bind<A, B>(parser, func);

        public static BindWithSelector<A, B, C> SelectMany<A, B, C>(
            this IParser<A> parser, 
            Func<A, IParser<B>> func, 
            Func<A, B, C> selector) => new BindWithSelector<A, B, C>(parser, func, selector);

    }
}
