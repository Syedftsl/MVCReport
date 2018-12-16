using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCReport.Startup))]
namespace MVCReport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
