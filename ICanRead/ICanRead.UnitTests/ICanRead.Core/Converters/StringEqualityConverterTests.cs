using ICanRead.Core.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ICanRead.UnitTests.ICanRead.Core.Converters
{
    public class StringEqualityConverterTests
    {
        [Fact]
        public void Convert_ValueEqualsParam_true()
        {
            var res = new StringEqualityConverter().Convert("ua", null, "ua", null);
            Assert.Equal(true, res);
        }
        [Fact]
        public void Convert_NullValueNullParam_False()
        {
            var res = new StringEqualityConverter().Convert(null, null, null, null);
            Assert.Equal(false, res);
        }

        [Fact]
        public void Convert_NullValueNotNullParam_False()
        {
            var res = new StringEqualityConverter().Convert(null, null, "ua", null);
            Assert.Equal(false, res);
        }
        [Fact]
        public void Convert_NotNullValueNullParam_False()
        {
            var res = new StringEqualityConverter().Convert("ua", null, null, null);
            Assert.Equal(false, res);
        }
        [Fact]
        public void Convert_NotStringParam_False()
        {
            var res = new StringEqualityConverter().Convert("ua", null, new object(), null);
            Assert.Equal(false, res);
        }
        [Fact]
        public void Convert_ValueNotEqualParam_False()
        {
            var res = new StringEqualityConverter().Convert("ua", null, "en", null);
            Assert.Equal(false, res);
        }
    }
}
