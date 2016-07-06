using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoveInn.Web.Startup))]
namespace MoveInn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
