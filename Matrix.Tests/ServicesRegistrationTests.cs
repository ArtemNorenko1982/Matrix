using System;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Matrix.Tests
{
    [TestFixture()]
    public class ServicesRegistrationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsAllServicesAreRegistered()
        {
            var serviceCollection = new ServiceCollection();
            
            var cfgBuilder = new ConfigurationBuilder();
            var cfg = cfgBuilder.Build();

            var startup = new Startup(cfg);
            startup.ConfigureServices(serviceCollection);

            var applicationLifetimeMock = new Mock<IApplicationLifetime>();
            serviceCollection.AddTransient(sp => applicationLifetimeMock.Object);
            var builder = new ContainerBuilder();
            builder.Populate(serviceCollection);

            var provider = new AutofacServiceProvider(builder.Build());

            var allResolved = false;

            var actualServices = serviceCollection.Where(s => s.ServiceType.FullName.StartsWith("Matrix"));

            foreach (var service in actualServices)
            {
                try
                {
                    var svc = provider.GetRequiredService(service.ServiceType);
                    allResolved = true;
                }
                catch (Exception exception)
                {
                    allResolved = false;
                }
            }

            Assert.IsTrue(allResolved);
        }
    }
}