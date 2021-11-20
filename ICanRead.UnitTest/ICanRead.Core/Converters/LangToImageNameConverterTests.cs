using ICanRead.Core.Converters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ICanRead.UnitTests.ICanRead.Core.Converters
{
    public class LangToImageNameConverterTests
    {
     
        [Fact]
        public void Convert_UnknownCurrentLang_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new LangToImageNameConverter()
                     .Convert("rt", null, "ru", null));
        }
        [Fact]
        public void Convert_NullCurrentLang_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new LangToImageNameConverter()
                    .Convert(null, null, "ru", null));
        }
        [Fact]
        public void Convert_NullParameter_ArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => new LangToImageNameConverter()
                    .Convert("ru", null, null, null));
        }
        [Fact]
        public void Convert_UnknownParameter_ArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => new LangToImageNameConverter()
                    .Convert("ru", null, "rt", null));
        }
        [Fact]
        public void Convert_RuCurrentLangAndRuBtn_rubtnclickedPng()
        {
            var res = new LangToImageNameConverter().Convert("ru", null, "ru", null);
            Assert.Equals("rubtnclicked.png", res);
        }
        [Fact]
        public void Convert_RuCurrentLangAndEnBtn_enbtnPng()
        {
            var res = new LangToImageNameConverter().Convert("ru", null, "en", null);
            Assert.Equals("enbtn.png", res);
        }
        [Fact]
        public void Convert_RuCurrentLangAndUaBtn_uabtnPng()
        {
            var res = new LangToImageNameConverter().Convert("ru", null, "ua", null);
            Assert.Equals("uabtn.png", res);
        }
        [Fact]
        public void Convert_UaCurrentLangAndUaBtn_uabtnclickedPng()
        {
            var res = new LangToImageNameConverter().Convert("ua", null, "ua", null);
            Assert.Equals("uabtnclicked.png", res);
        }
        [Fact]
        public void Convert_UaCurrentLangAndEnBtn_enbtnPng()
        {
            var res = new LangToImageNameConverter().Convert("ua", null, "en", null);
            Assert.Equals("enbtn.png", res);
        }
        [Fact]
        public void Convert_UaCurrentLangAndRuBtn_rubtnPng()
        {
            var res = new LangToImageNameConverter().Convert("ua", null, "ru", null);
            Assert.Equals("rubtn.png", res);
        }
        [Fact]
        public void Convert_EnCurrentLangAndEnBtn_enbtnclickedPng()
        {
            var res = new LangToImageNameConverter().Convert("en", null, "en", null);
            Assert.Equals("enbtnclicked.png", res);
        }
        [Fact]
        public void Convert_EnCurrentLangAndRuBtn_rubtnPng()
        {
            var res = new LangToImageNameConverter().Convert("en", null, "ru", null);
            Assert.Equals("rubtn.png", res);
        }
        [Fact]
        public void Convert_EnCurrentLangAndUaBtn_uabtnPng()
        {
            var res = new LangToImageNameConverter().Convert("en", null, "ua", null);
            Assert.Equals("uabtn.png", res);
        }
    }
}
