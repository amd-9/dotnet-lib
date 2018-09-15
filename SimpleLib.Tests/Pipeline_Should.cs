using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLib.Tests
{
    [TestFixture]
    public class Pipeline_Should
    {
        private readonly Pipeline _pipeline;
        public Pipeline_Should()
        {
            _pipeline = new Pipeline();
        }

        [Test]
        public void PluralizeMiddleAndUppercaseMiddleString()
        {
            List<string> files = new List<string>()
            {
                "foo",
                ".foo",
                "bar",
                "baz",
                ".baz"
            };

            var result = _pipeline.Do(files);

            Assert.AreEqual("FOOS", result);
        }
            
    }
}
