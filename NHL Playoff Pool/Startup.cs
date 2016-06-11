using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHL_Playoff_Pool.Startup))]
namespace NHL_Playoff_Pool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
