using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplicationTestAuth.Startup))]
namespace WebApplicationTestAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
