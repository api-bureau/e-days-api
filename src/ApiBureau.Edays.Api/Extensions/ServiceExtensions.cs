using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace ApiBureau.Edays.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddEdays(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EdaysSettings>(options => configuration.GetSection(nameof(EdaysSettings)).Bind(options));

        services.AddHttpClient<ApiConnection>()
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(20))
            .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(3) }));

        services.AddSingleton<EdaysClient>();

        return services;
    }
}
