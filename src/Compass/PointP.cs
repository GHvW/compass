using Compass.Shapes;
using System;


namespace Compass {

    public class PointP : IParser<Point> {

        private readonly IParser<double> parser;

        public PointP(IParser<double> parser) {
            this.parser = parser;
        }

        public (Point, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            (from x in this.parser
             from y in this.parser
             select new Point(x, y))
            .Call(bytes);
    }
}
