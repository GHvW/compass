using Compass.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class ShapeRecordP<A> : IParser<ShapeRecord<A>> {

        private readonly IParser<A> parser; 
        public ShapeRecordP(IParser<A> parser) {
            this.parser = parser;
        }

        public (ShapeRecord<A>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            return (from shapeTypeIndex in new LittleInt()
                    from shape in parser
                    select new ShapeRecord<A>(shapeTypeIndex.ToShapeType(), shape))
                   .Call(bytes);
        }
    }
}
