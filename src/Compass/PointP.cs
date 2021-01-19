using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class PointP : IParser<double> {

        public PointP() {
            this.parser = parser;
        }

        public (double, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            throw new NotImplementedException();
            
        }
    }
}
