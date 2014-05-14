using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PassStorage.Startup))]
namespace PassStorage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
