using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
using Ocelot.Provider.Consul;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json",
                       optional: false,
                       reloadOnChange: true);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOcelot().AddPolly().AddConsul().AddCacheManager(x => x.WithDictionaryHandle());

var app = builder.Build();

app.UseOcelot().Wait();

app.Run();