using Compass.Shapes;
using System;


namespace Compass {

    public class PointP : IParser<Point> {

        public PointP() { }

        public (Point, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            var parser = new LittleDouble();
            return (from x in parser
                    from y in parser
                    select new Point(x, y))
                   .Call(bytes);
        }
    }
}
