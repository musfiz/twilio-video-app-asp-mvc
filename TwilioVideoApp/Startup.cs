using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwilioVideoApp.Startup))]
namespace TwilioVideoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
