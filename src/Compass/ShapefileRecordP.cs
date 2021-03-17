using Compass.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class ShapefileRecordP : 
        IParser<ShapefileRecord<Point>>,
        IParser<ShapefileRecord<Polygon>> {

        public ShapefileRecordP() { }

        public (ShapefileRecord<Point>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            (from header in new IntP(Endian.Big).ReadRecordHeader()
             from shapeTypeIndex in new IntP(Endian.Little)
             from point in new DoubleP(Endian.Little).ReadPoints()
             select new ShapefileRecord<Point>(
                 header, 
                 new ShapeRecord<Point>(shapeTypeIndex.ToShapeType(), point)))
            .Call(bytes);

        (ShapefileRecord<Polygon>, ArraySegment<byte>)? IParser<ShapefileRecord<Polygon>>.Call(ArraySegment<byte> bytes) {
            throw new NotImplementedException();
        }
    }
}
