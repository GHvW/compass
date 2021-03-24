using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    //public class Take<A> : IParser<ImmutableList<A>> {
    public class Take<A> : IParser<List<A>> {

        private readonly int n;
        private readonly IParser<A> parser;

        public Take(int n, IParser<A> parser) {
            this.n = n;
            this.parser = parser;
        }

        public (List<A>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            Enumerable
                .Range(0, this.n)
                .Aggregate(new Return<List<A>>(new List<A>()), (IParser<List<A>> result, int _) => {
                    return (from list in result
                            from item in this.parser
                            select AddItem(list, item));
                })
                .Call(bytes);

        private static List<A> AddItem(List<A> list, A item) {
            list.Add(item);
            return list;
        }
    }
}
