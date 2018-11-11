using OpenGlBindingsGenerator;
using System;
using System.Linq;
using Xunit;

namespace OpenGlBindingsTest
{
    public class UnitTest1
    {
        [Fact]
        public void LoadSpecification()
        {
            var generator = new BindingGenerator();

            var delegates = generator.Features["GL_ES_VERSION_2_0"].Commands.Values.Select(x => x.ToDelegateString()).ToArray();

            Assert.NotEmpty(generator.Groups);
        }
    }
}
