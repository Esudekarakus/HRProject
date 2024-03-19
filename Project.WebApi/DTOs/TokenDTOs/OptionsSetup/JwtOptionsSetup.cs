using Microsoft.Extensions.Options;
using Project.Application.DTOs;

namespace Project.WebApi.DTOs.TokenDTOs.OptionsSetup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";
        private readonly IConfiguration _config;

        public JwtOptionsSetup(IConfiguration _config)
        {
            this._config= _config;
        }

        public void Configure(JwtOptions options)
        {
            _config.GetSection(SectionName).Bind(options);
        }
    }
}
