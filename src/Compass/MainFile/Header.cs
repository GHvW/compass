using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass.MainFile {

    public record Header(
        int FileCode,
        int FileLength,
        int Version,
        int ShapeType,
        HeaderBounds Bounds);
}
