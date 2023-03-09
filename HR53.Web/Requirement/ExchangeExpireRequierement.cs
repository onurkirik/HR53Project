using Microsoft.AspNetCore.Authorization;

namespace HR53.Web.Requirement
{
    public class ExchangeExpireRequierement : IAuthorizationRequirement
    {
    }
    public class ExchangeExpireRequirementHandler : AuthorizationHandler<ExchangeExpireRequierement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ExchangeExpireRequierement requirement)
        {

            var hasExchangeExpireClaim = context.User.HasClaim(x => x.Type == "ExchangeExpireDate");

            if (hasExchangeExpireClaim == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var exchangeExpireDate = context.User.FindFirst("ExchangeExpireDate");

            if (DateTime.Now > Convert.ToDateTime(exchangeExpireDate.Value))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;

        }
    }
}
