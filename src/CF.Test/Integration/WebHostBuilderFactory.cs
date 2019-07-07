﻿using CF.Api;
using CF.CustomerMngt.Infrastructure.DbContext;
using CF.CustomerMngt.Infrastructure.Repositories;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace CF.Test.Integration
{
    public class WebHostBuilderFactory<TStartup>: WebApplicationFactory<TStartup>
        where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("CfTest");
            base.ConfigureWebHost(builder);
        }

        protected override IWebHostBuilder CreateWebHostBuilder() =>
            WebHost.CreateDefaultBuilder()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
#if DEBUG
                .UseEnvironment("Development")
#endif
                .UseStartup<Startup>();
    }
}
