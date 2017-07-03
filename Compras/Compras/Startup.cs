using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Compras.Startup))]
namespace Compras
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
