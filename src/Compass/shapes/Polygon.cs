using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass.Shapes {

    public record Polygon(
        BoundingBox Box,
        int PointsCount, 
        int PartsCount, 
        IEnumerable<Point> Points,
        IEnumerable<int> Parts);
}
