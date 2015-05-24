using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Try426.Startup))]
namespace Try426
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
