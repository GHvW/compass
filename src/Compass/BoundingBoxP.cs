using Compass.Shapes;
using System;

namespace Compass {
    public class BoundingBoxP : IParser<BoundingBox> {

        private readonly IParser<double> parser;

        public BoundingBoxP(IParser<double> parser) {
            this.parser = parser;
        }

        public (BoundingBox, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            parser
                .Take(4)
                .Select(list => new BoundingBox(list[0], list[1], list[2], list[3]))
                .Call(bytes);
    }
}
