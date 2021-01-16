using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Compass.Test {

    public class ParserOpsTests {

        [Fact]
        public void SelectTest() {
            var bytes = new byte[] { 0b00000000, 0b00000000, 0b00100011, 0b00101000 };

            IParser<int> parser = new EndianOps(Endian.Big);

            var (result, _) =
                parser
                    .Select(x => x + 9)
                    .Call(bytes)
                    .Value;

            Assert.Equal(9009, result);
        }

        [Fact]
        public void SelectManyTest() {
            var bytes = new byte[] { 0b00000000, 0b00000000, 0b00100011, 0b00101000 };

            IParser<int> parser = new EndianOps(Endian.Big);

            var (result, _) =
                parser
                    .SelectMany(x => new Return<int>(x + 9))
                    .Call(bytes)
                    .Value;

            Assert.Equal(9009, result);
        }

        [Fact]
        public void SelectManyWithSelectorTest() {
            var bytes = new byte[] { 
                0b00000000, 0b00000000, 0b00100011, 0b00101000, 
                0b00000000, 0b00000000, 0b00100011, 0b00101000, 
                0b00000000, 0b00000000, 0b00100011, 0b00101000 };

            IParser<int> parser = new EndianOps(Endian.Big);

            var (result, _) =
                (from x in parser
                 from y in parser
                 select x + y)
                 .Call(bytes)
                 .Value;

            Assert.Equal(18000, result);
        }
    }
}
