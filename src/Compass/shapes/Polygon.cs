using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass.Shapes {

    public record Polygon(
        BoundingBox Box,
        int PartsCount, 
        int PointsCount, 
        IEnumerable<int> Parts,
        IEnumerable<Point> Points);
}
