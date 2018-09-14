using NUnit.Framework;
using System;

namespace SimpleLib.Tests
{
    [TestFixture]
    public class Greeter_Should
    {
        private readonly Greeter _greeter;
        public Greeter_Should()
        {
            _greeter = new Greeter();
        }

        [Test]
        public void SayHelloWorld()
        {
            var result = _greeter.SayHello();

            Assert.AreSame("Hello, World!", result);
        }
    }
}
