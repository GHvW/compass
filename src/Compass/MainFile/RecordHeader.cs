using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass.MainFile {

    /// <summary>
    /// ContentLength is measured in 16-bit words
    /// </summary>
    public record RecordHeader(int RecordNumber, int ContentLength);
}
