using System.Linq;
using NJsonSchema;
using Statiq.Common;
using Statiq.Core;
using Statiq.Web.Pipelines;

namespace Statiqdev
{
    public class SchemaPipeline : Pipeline
    {
        public SchemaPipeline()
        {
            // DependencyOf.Add(nameof(Content)); 

            InputModules = new ModuleList
            {
                new ExecuteConfig(
                    Config.FromContext(ctx
                        => new ReadWeb(ctx.Settings.GetString(SiteKeys.SchemaUri))))
            };

            ProcessModules = new ModuleList
            {
                new ExecuteConfig(
                    Config.FromDocument(async (doc, ctx) =>
                    {
                        var schema = await JsonSchema.FromJsonAsync(await doc.GetContentStringAsync());

                        return doc.Clone(new MetadataDictionary
                        {
                            ["Definitions"] = schema.Definitions.Select(definition
                                => definition.Value.ToDocument(definition.Key))
                        });
                    }))
            };
        }
    }
}