using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace rivals.tests
{
    public class ConfigurationTest : IClassFixture<DependencyInjectionClassFixture>
    {
        [Fact]
        public void CanReadConfiguration()
        {
            var configRoot = DIFixture.Configuration;

            var jsonConfigData = configRoot.GetValue<String>("SampleConfigKey");
            var userSecretsConfigData = configRoot.GetValue<String>("SecretSampleConfigKey");
            var keyVaultConfigData = configRoot.GetValue<String>("UnitTest:KeyVaultSecretSampleConfigKey");

            Assert.Equal("Config Value", jsonConfigData);
            Assert.Equal("Secret Config Value", userSecretsConfigData);
            Assert.Equal("Key VaultConfig Value", keyVaultConfigData);
        }

        public ConfigurationTest(DependencyInjectionClassFixture fixture)
        {
            this.DIFixture = fixture;
        }

        DependencyInjectionClassFixture DIFixture { get; set; }

    }
}
