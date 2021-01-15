using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {
    //public interface IParserOps<A> : IParser<A> {

    //    public Map<> Select() =>
    //}
    public static class ParserOps {

        public static Map<A, B> Select<A, B>(this IParser<A> parser, Func<A, B> func) =>
            new Map<A, B>(parser, func);

        public static Bind<A, B> SelectMany<A, B>(this IParser<A> parser, Func<A, IParser<B>> func) =>
            new Bind<A, B>(parser, func);
    }
}
