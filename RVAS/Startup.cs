using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RVAS.Startup))]
namespace RVAS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
