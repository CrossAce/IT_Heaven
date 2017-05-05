using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT_Heaven.Startup))]
namespace IT_Heaven
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
