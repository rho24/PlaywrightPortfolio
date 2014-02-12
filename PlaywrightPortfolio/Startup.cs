using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlaywrightPortfolio.Startup))]
namespace PlaywrightPortfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
