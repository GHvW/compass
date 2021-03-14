using Compass.MainFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass {

    public class MainFileHeaderP : IParser<MainFile.Header> {


        public MainFileHeaderP() { }

        public (MainFile.Header, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            var littleInt = new IntP(Endian.Little);

            return (from start in new IntP(Endian.Big).Take(7)
                    from version in littleInt
                    from shapeType in littleInt
                    from bounds in new DoubleP(Endian.Little).Take(8)
                    select new MainFile.Header(
                        start[0], 
                        start[6], 
                        version, 
                        shapeType,
                        new MainFile.HeaderBounds(
                            bounds[0],
                            bounds[1],
                            bounds[2],
                            bounds[3],
                            bounds[4] == 0.0 ? null : bounds[4],
                            bounds[5] == 0.0 ? null : bounds[5],
                            bounds[6] == 0.0 ? null : bounds[6],
                            bounds[7] == 0.0 ? null : bounds[7])))
                    .Call(bytes);
        }
    }
}
