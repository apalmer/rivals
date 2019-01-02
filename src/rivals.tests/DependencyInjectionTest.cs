using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace rivals.tests
{
    public class DependencyInjectionTest
    {
        [Fact]
        public void Test1()
        {
            var services = TestHelper.GetServices();
            var dependency = services.GetService<logic.Game.DuelManager>();

            Assert.NotNull(dependency);
        }
    }
}
