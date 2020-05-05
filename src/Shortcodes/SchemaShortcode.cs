using System;
using System.Collections.Generic;
using System.Linq;
using NJsonSchema;
using Statiq.Common;
using System.Xml.Linq;
using Duck.Pipelines;

namespace Duck.Shortcodes
{
    public class SchemaShortCode : SyncShortcode
    {
        public override ShortcodeResult Execute(KeyValuePair<string, string>[] args, string content, IDocument document, IExecutionContext context)
        {
            var type = args.FirstOrDefault(x => x.Key?.Equals("type", StringComparison.OrdinalIgnoreCase) ?? false).Value;
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new InvalidOperationException("JSON Schema type is missing.");
            }

            var required = false;
            var requiredString = args.FirstOrDefault(x => x.Key?.Equals("required", StringComparison.OrdinalIgnoreCase) ?? false).Value;
            if (!string.IsNullOrWhiteSpace(requiredString))
            {
                if (requiredString.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    required = true;
                }
            }

            // Get the definition.
            var definition = context.Outputs
                .FromPipeline(nameof(SchemaParsingPipeline))
                .First()
                .GetChildren(Constants.Duck.JsonSchema.Definitions)
                .OfType<ObjectDocument<JsonSchema>>()
                .First(x => x.Destination == type)
                .Object;

            var table = new XElement("table", new XAttribute("class", "table"));
            var header = new XElement("tr");
            header.Add(new XElement("th", "Field"));
            header.Add(new XElement("th", "Type"));
            header.Add(new XElement("th", "Description"));
            table.Add(header);

            foreach (var (key, value) in definition.Properties.Where(x => x.Value.IsRequired == required))
            {
                var description = new XElement("td", value.Title);
                if(value.Description != null)
                {
                    description.Add(new XElement("br"));
                    description.Add(new XElement("i", value.Description));
                }

                var kind = new XElement("td");
                if(value.Type.ToString() == "None") {
                    var foo = args.FirstOrDefault(x => x.Key?.Equals($"{key}Type", StringComparison.OrdinalIgnoreCase) ?? false).Value;
                    if(foo == null) {
                        throw new InvalidOperationException($"Could not find type '{key}'.");
                    }
                    kind.Add(new XElement("span", foo));
                } else {
                    kind.Add(new XElement("span", value.Type.ToString()));
                }

                var row = new XElement("tr");
                row.Add(new XElement("td", key));
                row.Add(kind);
                row.Add(description);
                table.Add(row);
            }

            return table.ToString();
        }
    }
}