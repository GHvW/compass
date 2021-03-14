﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass.Shapes {

    public record BoundingBox(
        double XMin,
        double YMin,
        double XMax,
        double YMax);
}
