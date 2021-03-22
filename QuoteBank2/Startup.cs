using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuoteBank2.Startup))]
namespace QuoteBank2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
