using System.Collections.Generic;
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

                        var definitions = new List<IDocument>();
                        definitions.Add(schema.ToDocument("Root"));
                        definitions.AddRange(schema.Definitions.Select(definition => definition.Value.ToDocument(definition.Key)));

                        return doc.Clone(new MetadataDictionary
                        {
                            ["Definitions"] = definitions
                        });
                    }))
            };
        }
    }
}