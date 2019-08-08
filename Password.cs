using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace SkillHub
{
  
    public static class Password
    {
        public static void PasswordSetting(this IServiceCollection services){
             services.Configure<IdentityOptions> (options=>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase= false;
                options.Password.RequireLowercase = false;
            });

        }
    }
}