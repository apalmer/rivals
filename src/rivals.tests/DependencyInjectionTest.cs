using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace rivals.tests
{
    public class DependencyInjectionTest : IClassFixture<DependencyInjectionClassFixture>
    {
        [Fact]
        public void Test1()
        {
            var services = DIFixture.ServiceProvider;
            var dependency = services.GetService<logic.Game.DuelManager>();

            Assert.NotNull(dependency);
        }

        public DependencyInjectionTest(DependencyInjectionClassFixture fixture)
        {
            this.DIFixture = fixture;
        }

        DependencyInjectionClassFixture DIFixture { get; set; }
    }
}
