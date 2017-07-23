using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventorySales.Startup))]
namespace InventorySales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
