using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaVentas.Startup))]
namespace SistemaVentas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
