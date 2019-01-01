using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace rivals.tests
{
    public class ConfigurationTest
    {
        [Fact]
        public void CanReadConfiguration()
        {
            var configRoot = TestHelper.GetConfiguration();

            var jsonConfigData = configRoot.GetValue<String>("SampleConfigKey");
            var userSecretsConfigData = configRoot.GetValue<String>("SecretSampleConfigKey");

            Assert.Equal("Config Value", jsonConfigData);
            Assert.Equal("Secret Config Value", userSecretsConfigData);
        }
    }
}
