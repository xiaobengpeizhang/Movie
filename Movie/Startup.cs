using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movie.Startup))]
namespace Movie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
