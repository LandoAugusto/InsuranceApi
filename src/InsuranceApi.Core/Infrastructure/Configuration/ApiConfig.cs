namespace InsuranceApi.Core.Infrastructure.Configuration
{
    public class ApiConfig
    {
        public string? Environment { get; set; }
        public string? ApplicationName { get; set; } = "Insurance.Api";
        public string? RoutePrefix { get; set; }
        public bool UseResponseCompression { get; set; }

        /// <summary>
        /// Gets or sets the JWT configuration.
        /// </summary>
        public JwtConfig Jwt { get; set; }
    }
}
