using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public static class BigIntExtensions {

        public static RecordHeaderP ReadRecordHeader(this IParser<int> @this) =>
            new RecordHeaderP(@this);
    }
}
