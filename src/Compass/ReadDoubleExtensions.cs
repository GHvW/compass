using Compass.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public static class ReadDoubleExtensions {

        public static IParser<Point> ReadPoints(this IParser<double> @this) =>
            new PointP(@this);
    }
}
