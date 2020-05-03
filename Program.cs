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
                .AddSetting(
                    Keys.DestinationPath,
                    Config.FromDocument(doc => doc.Source.Parent.Segments.Last().SequenceEqual("posts".AsMemory())
                        ? new NormalizedPath("blog")
                            .Combine(doc.GetDateTime(WebKeys.Published).ToString("yyyy/MM/dd"))
                            .Combine(doc.Destination.FileName.ChangeExtension(".html"))
                        : doc.Destination.ChangeExtension(".html")))
                .AddSetting("EditLink", Config.FromDocument((doc, ctx) => new NormalizedPath("https://github.com/duckhq/docs/edit/develop/input").Combine(doc.Source.GetRelativeInputPath())))
                .AddSetting(SiteKeys.SchemaUri, "https://raw.githubusercontent.com/duckhq/duck/master/schemas/v0.14.json")
                .AddShortcode("JsonSchema", typeof(SchemaShortCode))
                .AddPipelines()
                .RunAsync();
    }
}
