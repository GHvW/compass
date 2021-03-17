using Compass.MainFile;
using System;


namespace Compass {

    public class RecordHeaderP : IParser<RecordHeader> {

        private readonly IParser<int> bigIntReader;

        public RecordHeaderP(IParser<int> bigIntReader) {
            this.bigIntReader = bigIntReader;
        }

        public (RecordHeader, ArraySegment<byte>)? Call(ArraySegment<byte> bytes) {

            return (from n in bigIntReader
                    from contentLen in bigIntReader
                    select new RecordHeader(n, contentLen))
                   .Call(bytes);
        }
    }
}
