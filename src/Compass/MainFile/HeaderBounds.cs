using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass.MainFile {

    public record HeaderBounds(
        double XMin,
        double YMin,
        double XMax,
        double YMax,
        double? ZMin,
        double? ZMax,
        double? MMin,
        double? MMax);
}
