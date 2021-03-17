using Compass.MainFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public record ShapefileRecord<A>(
        RecordHeader header,
        ShapeRecord<A> shapeRecord);
}
