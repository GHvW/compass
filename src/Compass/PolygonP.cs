using Compass.Shapes;
using System;

namespace Compass {

    public class PolygonP : IParser<Polygon> {

        public PolygonP() { }

        public (Polygon, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            var doubleReader = new LittleDouble();
            var intReader = new LittleInt();

            return (from bounds in new BoundingBoxP() 
                    from partsCount in intReader
                    from pointsCount in intReader
                    from parts in intReader.Take(partsCount)
                    from points in new PointP().Take(pointsCount)
                    select new Polygon(bounds, partsCount, pointsCount, parts, points))
                   .Call(bytes);
        }
    }
}
