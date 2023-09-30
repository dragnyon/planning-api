using Microsoft.Extensions.Options;

namespace planning.API.OptionsSetup;

public class SmtpOptionsSetup : IConfigureOptions<SmtpOptions>
{
    private const string SectionName = "Smtp";
    private readonly IConfiguration _configuration;

    public SmtpOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(SmtpOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}