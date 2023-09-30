﻿using Microsoft.Extensions.Options;

namespace planning.API.OptionsSetup;

public class EncryptionOptionsSetup : IConfigureOptions<EncryptionOptions>
{
    private const string SectionName = "Encryption";
    private readonly IConfiguration _configuration;

    public EncryptionOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(EncryptionOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}