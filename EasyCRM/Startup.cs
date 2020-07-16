using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyCRM.Startup))]
namespace EasyCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
