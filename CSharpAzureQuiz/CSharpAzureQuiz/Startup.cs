using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharpAzureQuiz.Startup))]
namespace CSharpAzureQuiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
