using System.Linq;
using Xunit;

namespace Compass.Test {

    public class EndianOpsTests {

        [Theory] 
        [InlineData(new byte[] { 0b00100001, 0b00100001, 0b11110111, 0b10111110 })]
        [InlineData(new byte[] { 0b00100001, 0b00100001, 0b11110111, 0b10111110, 0b00110001, 0b00100011, 0b11110011, 0b10011110 })]
        public void ReadBigEndianInt(byte[] bytes) {

            //IParser<int> ops = new EndianOps(Endian.Big);
            var (result, _) = new IntP(Endian.Big).Call(bytes).Value;

            var expected = 555_874_238;
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ReadBigEndianIntRemainingBytesLeftAreCorrect() { 
            var initial = new byte[] { 0b00100001, 0b00100001, 0b11110111, 0b10101110, 0b00110001, 0b00100011, 0b11110011, 0b10011110 };

            var (_, rest) = new IntP(Endian.Big).Call(initial).Value;

            var expectedBytes = new byte[] { 0b00110001, 0b00100011, 0b11110011, 0b10011110 };

            foreach (var (expected, actual) in rest.Zip(expectedBytes)) {

                Assert.Equal(expected, actual);
            }
        }

        [Theory]
        [InlineData(new byte[] { 0b10111110, 0b11110111, 0b00100001, 0b00100001 })]
        [InlineData(new byte[] { 0b10111110, 0b11110111, 0b00100001, 0b00100001, 0b00110001, 0b00100011, 0b11110011, 0b10011110 })]
        public void ReadLittleIndianInt(byte[] bytes) {

            var (result, _) = 
                new IntP(Endian.Little)
                    .Call(bytes)
                    .Value;

            var expected = 555_874_238;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new byte[] { 0b01000000, 0b11001000, 0b00011100, 0b11010110, 0b11100110, 0b00110001, 0b11111000, 0b10100001 })]
        [InlineData(new byte[] { 0b01000000, 0b11001000, 0b00011100, 0b11010110, 0b11100110, 0b00110001, 0b11111000, 0b10100001,
        0b01001100, 0b11011100, 0b01011100, 0b11000100, 0b10100110, 0b00110101, 0b11011000, 0b10101001 })]
        public void ReadBigndianDouble(byte[] bytes) {

            var ops = new DoubleP(Endian.Big);

            var (result, _) = ops.Call(bytes).Value;

            var expected = 12345.6789;
            Assert.Equal(expected, result);
        }
    }
}
