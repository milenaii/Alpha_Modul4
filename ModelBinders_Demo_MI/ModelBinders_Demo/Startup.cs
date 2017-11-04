using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModelBinders_Demo.Startup))]
namespace ModelBinders_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
