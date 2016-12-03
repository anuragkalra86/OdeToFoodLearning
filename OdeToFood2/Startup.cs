using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OdeToFood2.Startup))]
namespace OdeToFood2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
