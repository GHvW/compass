using Compass.MainFile;
using System;


namespace Compass {

    public class RecordHeaderP : IParser<RecordHeader> {

        public RecordHeaderP() { }

        public (RecordHeader, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {
            var bigIntReader = new BigInt();

            return (from n in bigIntReader
                    from contentLen in bigIntReader
                    select new RecordHeader(n, contentLen))
                   .Call(bytes);
        }
    }
}
