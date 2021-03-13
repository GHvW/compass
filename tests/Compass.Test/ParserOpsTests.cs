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

            var (result, _) =
                new IntP(Endian.Big)
                    .Select(x => x + 9)
                    .Call(bytes)
                    .Value;

            Assert.Equal(9009, result);
        }

        [Fact]
        public void SelectManyTest() {
            var bytes = new byte[] { 0b00000000, 0b00000000, 0b00100011, 0b00101000 };

            var (result, _) =
                new IntP(Endian.Big)
                    .SelectMany(x => new Return<int>(x + 9))
                    .Call(bytes)
                    .Value;

            Assert.Equal(9009, result);
        }

        [Fact]
        public void SelectManyWithSelectorTest() {
            var bytes = new byte[] { 
                0b00000000, 0b00000000, 0b00100011, 0b00101000, 
                0b00000000, 0b00000000, 0b00011111, 0b01000000,
                0b00000000, 0b00000000, 0b00100011, 0b00101000 };

            var parser = new IntP(Endian.Big);

            var (result, _) =
                (from x in parser
                 from y in parser
                 select x + y)
                 .Call(bytes)
                 .Value;

            Assert.Equal(17000, result);
        }


        [Fact]
        public void TakeTest() {
            var bytes = new byte[] { 
                0b00000000, 0b00000000, 0b00100011, 0b00101000, 
                0b00000000, 0b00000000, 0b00011111, 0b01000000,
                0b00000000, 0b00000000, 0b00100011, 0b00101000 };

            var parser = new IntP(Endian.Big);

            var (result, _) =
                 parser
                    .Take(2)
                    .Call(bytes)
                    .Value;

            Assert.Equal(9000, result[0]);
            Assert.Equal(8000, result[1]);
        }
    }
}
