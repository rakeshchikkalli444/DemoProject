using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPASEX1.Startup))]
namespace MVCPASEX1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
