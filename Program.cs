using System.Threading.Tasks;
using Duck.Shortcodes;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace Duck
{
    public static class Program
    {
        public static async Task<int> Main(string[] args) =>
            await Bootstrapper.Factory
                .CreateWeb(args)
                .AddSetting(Keys.Host, "duckhq.org")
                .AddSetting(Constants.Deployment.Owner, "duckhq")
                .AddSetting(Constants.Deployment.Repository, "docs")
                .AddSetting(Constants.Deployment.Branch, "master")
                .AddSetting(Keys.LinksUseHttps, true)
                .AddSetting(Constants.EditLink, Config.FromDocument((doc, ctx) => "https://github.com/duckhq/docs/edit/develop/input/" + doc.Source.GetRelativeInputPath()))
                .AddSetting(Constants.SchemaUri, "https://raw.githubusercontent.com/duckhq/duck/master/schemas/v0.14.json")
                .AddShortcode("JsonSchema", typeof(SchemaShortCode))
                .AddShortcode("Children", typeof(ChildrenShortcode))
                .AddPipelines()
                .RunAsync();
    }
}
