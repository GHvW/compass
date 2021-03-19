using Compass.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class ShapefileRecordP<A> : IParser<ShapefileRecord<A>> {

        private readonly IParser<ShapeRecord<A>> parser;

        public ShapefileRecordP(IParser<ShapeRecord<A>> parser) {
            this.parser = parser;
        }

        public (ShapefileRecord<A>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            return (from recordHeader in new RecordHeaderP()
                    from shapeRecord in parser
                    select new ShapefileRecord<A>(recordHeader, shapeRecord))
                   .Call(bytes);
        }
    }
}
