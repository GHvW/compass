using Compass.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class PolygonShapefileRecordP : IParser<ShapefileRecord<Polygon>> {

        public PolygonShapefileRecordP() { }

        public (ShapefileRecord<Polygon>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            (from header in new RecordHeaderP()
             from shapeTypeIndex in new LittleInt()
             from polygon in new PolygonP()
             select new ShapefileRecord<Polygon>(
                 header,
                 new ShapeRecord<Polygon>(shapeTypeIndex.ToShapeType(), polygon)))
            .Call(bytes);
    }

    public class PointShapefileRecordP : IParser<ShapefileRecord<Point>> {

        public PointShapefileRecordP() { }

        public (ShapefileRecord<Point>, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            (from header in new RecordHeaderP()
             from shapeTypeIndex in new LittleInt()
             from point in new PointP()
             select new ShapefileRecord<Point>(
                 header,
                 new ShapeRecord<Point>(shapeTypeIndex.ToShapeType(), point)))
            .Call(bytes);
    }
}
