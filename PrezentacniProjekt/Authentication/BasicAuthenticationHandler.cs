using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace PrezentacniProjekt
{
    /// <summary>
    /// Handles basic authentication by validating credentials from the Authorization header.
    /// TODO: Replace the simple credential validation logic with your actual user validation mechanism before using in production.
    /// PLAN: DB for quick implementation. Better: learn how to use azure key vault for storing credentials securely and implement proper user management.
    /// </summary>
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder)
            : base(options, logger, encoder)
        {
        }


        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));
            }

            try
            {
                var authHeaderValue = Request.Headers["Authorization"].ToString();
                if (string.IsNullOrWhiteSpace(authHeaderValue))
                {
                    return Task.FromResult(AuthenticateResult.Fail("Empty Authorization Header"));
                }

                var authHeader = AuthenticationHeaderValue.Parse(authHeaderValue);
                if (string.IsNullOrEmpty(authHeader.Parameter))
                {
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
                }
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                var username = credentials[0];
                var password = credentials[1];

                if (IsValidUser(username, password))
                {
                    var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Name, username),
            };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }

                return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));
            }
            catch
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }
        }

        private bool IsValidUser(string username, string password)
        {
            // TODO: Replace with your actual user validation logic
            // This is a simple example - DO NOT use in production!
            return username == "admin" && password == "password";
        }
    }
}