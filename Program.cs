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
                .AddSetting(Keys.LinksUseHttps, true)
                .AddSetting(Constants.EditLink, ConfigureEditLink())
                .ConfigureDuck("duckhq", "duck", "master", "0.14.0")
                .ConfigureSite("duckhq", "docs", "develop")
                .ConfigureDeployment(deployBranch: "master")
                .AddShortcode("JsonSchema", typeof(SchemaShortCode))
                .AddShortcode("Children", typeof(ChildrenShortcode))
                .AddShortcode("Download", typeof(DownloadLinkShortcode))
                .AddPipelines()
                .RunAsync();

        private static Config<string> ConfigureEditLink()
        {
            return Config.FromDocument((doc, ctx) =>
            {
                return string.Format("https://github.com/{0}/{1}/edit/{2}/input/{3}",
                    ctx.GetString(Constants.Site.Owner),
                    ctx.GetString(Constants.Site.Repository),
                    ctx.GetString(Constants.Site.Branch),
                    doc.Source.GetRelativeInputPath());
            });
        }
    }
}
