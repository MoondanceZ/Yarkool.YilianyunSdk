using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Qc.YilianyunSdk.Test
{
    public class Tests
    {
        private string accessToken = "";
        private string machineCode = "";
        private ServiceCollection services;
        private ServiceProvider serviceProvider;
        [SetUp]
        public void Setup()
        {
            services = new ServiceCollection();

            services.AddYilianyunSdk<YilianyunSdk.DefaultYilianyunSdkHook>(opt =>
            {
                // 应用ID请自行前往 dev.10ss.net 获取
                opt.ClientId = "";
                opt.ClientSecret = "";
                opt.YilianyunClientType = YilianyunClientType.自有应用;
            });
            serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public void TestPrintText()
        {
            var text = """
                        <MC>0,00000,0</MC>
                        <FS2>  **测试**</FS2>
                        </FS>
            """;
            var yilianyunService = serviceProvider.GetService<YilianyunService>();
            var outputModel = yilianyunService.PrintText(accessToken, machineCode, text, Guid.NewGuid().ToString("N"));

            Assert.NotNull(outputModel);
            Assert.AreEqual(outputModel.IsSuccess(), true);
        }

        [Test]
        [TestCase("2872048714")]
        public void TestReprint(string orderId)
        {
            var yilianyunService = serviceProvider.GetService<YilianyunService>();
            var outputModel = yilianyunService.PrinterOrderReprint(accessToken, machineCode, orderId);

            Assert.NotNull(outputModel);
            Assert.AreEqual(outputModel.IsSuccess(), true);
        }
    }
}