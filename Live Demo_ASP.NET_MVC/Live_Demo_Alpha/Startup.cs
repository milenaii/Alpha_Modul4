using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Live_Demo_Alpha.Startup))]
namespace Live_Demo_Alpha
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
