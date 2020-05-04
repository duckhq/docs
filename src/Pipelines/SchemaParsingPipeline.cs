using System.Collections.Generic;
using System.Linq;
using NJsonSchema;
using Statiq.Common;
using Statiq.Core;

namespace Duck.Pipelines
{
    public class SchemaParsingPipeline : Pipeline
    {
        public SchemaParsingPipeline()
        {
            InputModules = new ModuleList
            {
                new ExecuteConfig(
                    Config.FromContext(ctx
                        => new ReadWeb(ctx.Settings.GetString(Constants.SchemaUri))))
            };

            ProcessModules = new ModuleList
            {
                new ExecuteConfig(
                    Config.FromDocument(async (doc, ctx) =>
                    {
                        var schema = await JsonSchema.FromJsonAsync(await doc.GetContentStringAsync());

                        var definitions = new List<IDocument> { schema.ToDocument(Constants.JsonSchema.Root) };
                        definitions.AddRange(schema.Definitions.Select(definition => definition.Value.ToDocument(definition.Key)));

                        return doc.Clone(new MetadataDictionary
                        {
                            [Constants.JsonSchema.Definitions] = definitions
                        });
                    }))
            };
        }
    }
}