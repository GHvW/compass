using Compass.Shapes;
using System;

namespace Compass {

    public class PolygonP : IParser<Polygon> {

        public PolygonP() { }

        public (Polygon, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            var doubleReader = new DoubleP(Endian.Little);
            var intReader = new IntP(Endian.Little);

            return (from bounds in doubleReader.ReadBoundingBox() 
                    from partsCount in intReader
                    from pointsCount in intReader
                    from parts in intReader.Take(partsCount)
                    from points in doubleReader.ReadPoints().Take(pointsCount)
                    select new Polygon(bounds, partsCount, pointsCount, parts, points))
                   .Call(bytes);
        }
    }
}
