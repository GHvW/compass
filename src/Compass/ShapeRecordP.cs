using Compass.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class ShapeRecordP :
        IParser<ShapeRecord<Point>>,
        IParser<ShapeRecord<Polygon>> {

        public (ShapeRecord<Point>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            throw new NotImplementedException();
        }

        (ShapeRecord<Polygon>, ArraySegment<byte>)? IParser<ShapeRecord<Polygon>>.Call(ArraySegment<byte> bytes) {
            throw new NotImplementedException();
        }
    }
}
