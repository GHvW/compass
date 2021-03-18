using Compass.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    //public class ShapeRecordP :
    //    IParser<ShapeRecord<Point>>,
    //    IParser<ShapeRecord<Polygon>> {

    //    public ShapeRecordP() { }

    //    public (ShapeRecord<Point>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
    //        return (from shapeTypeIndex in new IntP(Endian.Little)
    //                from points in new DoubleP(Endian.Little).ReadPoints()
    //                select new ShapeRecord<Point>(shapeTypeIndex.ToShapeType(), points))
    //               .Call(bytes);
    //    }

    //    (ShapeRecord<Polygon>, ArraySegment<byte>)? IParser<ShapeRecord<Polygon>>.Call(ArraySegment<byte> bytes) {
    //        return (from shapeTypeIndex in new IntP(Endian.Little)
    //                from polygons in new PolygonP()
    //                select new ShapeRecord<Polygon>(shapeTypeIndex.ToShapeType(), polygons))
    //               .Call(bytes);
    //    }
    //}
}
