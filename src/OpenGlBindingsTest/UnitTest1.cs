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

            var str = generator.Features["GL_ES_VERSION_2_0"].ToBindingClassString();

            Assert.NotEmpty(generator.Groups);
        }
    }
}
