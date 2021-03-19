using System;
using System.Collections.Generic;

namespace Compass {

    public static class ParserOps {

        public static IParser<B> Select<A, B>(this IParser<A> parser, Func<A, B> func) =>
            new Map<A, B>(parser, func);

        public static IParser<B> SelectMany<A, B>(this IParser<A> parser, Func<A, IParser<B>> func) =>
            new Bind<A, B>(parser, func);

        public static IParser<C> SelectMany<A, B, C>(
            this IParser<A> parser, 
            Func<A, IParser<B>> func, 
            Func<A, B, C> selector) => new BindWithSelector<A, B, C>(parser, func, selector);

        public static IParser<List<A>> Take<A>(this IParser<A> parser, int n) =>
            new Take<A>(n, parser);

        public static IParser<ShapeRecord<A>> AsShapeRecord<A>(this IParser<A> @this) =>
            new ShapeRecordP<A>(@this);

        public static IParser<ShapefileRecord<A>> ShapefileRecord<A>(this IParser<ShapeRecord<A>> @this) =>
            new ShapefileRecordP<A>(@this);
    }
}
