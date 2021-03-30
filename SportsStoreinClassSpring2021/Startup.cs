using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportsStoreinClassSpring2021.Startup))]
namespace SportsStoreinClassSpring2021
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
