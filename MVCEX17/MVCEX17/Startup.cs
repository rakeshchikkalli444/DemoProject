using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCEX17.Startup))]
namespace MVCEX17
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
