using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace Statiqdev
{
    public static class Program
    {
        public static async Task<int> Main(string[] args) =>
            await Bootstrapper.Factory
                .CreateWeb(args)
                .AddSetting(Keys.Host, "duckhq.org")
                .AddSetting(Keys.LinksUseHttps, true)
                .AddSetting(SiteKeys.EditLink, Config.FromDocument((doc, ctx) => "https://github.com/duckhq/docs/edit/develop/input/" + doc.Source.GetRelativeInputPath()))
                .AddSetting(SiteKeys.SchemaUri, "https://raw.githubusercontent.com/duckhq/duck/master/schemas/v0.14.json")
                .AddShortcode("JsonSchema", typeof(SchemaShortCode))
                .AddPipelines()
                .RunAsync();
    }
}
