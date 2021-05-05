using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RepoRapport.Startup))]
namespace RepoRapport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
