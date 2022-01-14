using DataAccess;
using DataAccess.CQRS.Queries.UsersQueries;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace warehouse_management_system.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IQueryExecutor _queryExecutor;
        private const string AuthorizationHeader = "Authorization";

        public BasicAuthenticationHandler(
            IQueryExecutor queryExecutor,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory loggerFactory, UrlEncoder encoder,
            ISystemClock clock)
            : base(options, loggerFactory, encoder, clock)
        {
            _queryExecutor = queryExecutor;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null) // sprawdza czy endpoint ma flage AllowAnonymous
            {
                return AuthenticateResult.NoResult();
            }

            if (!Request.Headers.ContainsKey(AuthorizationHeader)) // sprawdza czy request posiada header "Authorization" - PostMan
            {
                return AuthenticateResult.Fail("Missing authorization header."); // // Not Authenticated
            }

            User user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers[AuthorizationHeader]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                // rozdziela username:password -> username = [0], password = [1]
                var username = credentials[0];
                var password = credentials[1];

                var query = new GetUserQuery()
                {
                    UserName = username
                };

                user = await Helper.GetUser(_queryExecutor, query);

                if (user is null || !user.HasCorrectPassword(password))
                {
                    return AuthenticateResult.Fail("Invalid username or password.");
                }

            }
            catch
            {
                return AuthenticateResult.Fail("Authorization failed. Unidentified Error occured."); // Not Authenticated
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
