using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public static class LittleDoubleExtensions {

        public static PointP ReadPoints(this IParser<double> @this) =>
            new PointP(@this);

        public static BoundingBoxP ReadBoundingBox(this IParser<double> @this) =>
            new BoundingBoxP(@this);
    }
}
