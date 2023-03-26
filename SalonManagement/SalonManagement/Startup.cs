using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalonManagement.Startup))]
namespace SalonManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
