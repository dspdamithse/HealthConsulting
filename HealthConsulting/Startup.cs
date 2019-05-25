using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthConsulting.Startup))]
namespace HealthConsulting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
