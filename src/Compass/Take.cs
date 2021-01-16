using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class Take<A> : IParser<ImmutableList<A>> {

        private readonly int n;
        private readonly IParser<A> parser;

        public Take(int n, IParser<A> parser) {
            this.n = n;
            this.parser = parser;
        }

        public (ImmutableList<A>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            Enumerable
                .Range(0, this.n)
                .Select(_ => this.parser)
                .Aggregate(new Return<ImmutableList<A>>(ImmutableList<A>.Empty) as IParser<ImmutableList<A>>, (result, p) => {
                    return (from list in result
                            from item in p
                            select list.Add(item)); //works with ImmutableList but not List
                    //return result.SelectMany(list => {
                    //    return p.SelectMany(a => {
                    //        list.Add(a);
                    //        return new Return<List<A>>(list);
                    //    });
                    //});
                })
                .Call(bytes);
            //throw new NotImplementedException();
    }
}
