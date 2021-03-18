using Compass.Shapes;
using System;

namespace Compass {
    public class BoundingBoxP : IParser<BoundingBox> {

        public BoundingBoxP() { }

        public (BoundingBox, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) =>
            new LittleDouble()
                .Take(4)
                .Select(list => new BoundingBox(list[0], list[1], list[2], list[3]))
                .Call(bytes);
    }
}
