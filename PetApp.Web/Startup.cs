using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetApp.Web.Startup))]
namespace PetApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
