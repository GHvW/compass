using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class Take<A> : IParser<A> {

        private readonly int n;
        private readonly IParser<A> parser;

        public Take(int n, IParser<A> parser) {
            this.n = n;
            this.parser = parser;
        }

        public (A, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            //Enumerable
            //    .Range(0, this.n)
            //    .Select(_ => this.parser)
            //    .Aggregate(new Return<List<A>>> (new List<A>()), (result, p) => {

            //    });
            throw new NotImplementedException();
        }
    }
}
