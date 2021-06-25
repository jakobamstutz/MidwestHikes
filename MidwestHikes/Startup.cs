using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MidwestHikes.Startup))]
namespace MidwestHikes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
