using System;
using System.Collections.Generic;
using System.Linq;
using NJsonSchema;
using Statiq.Common;
using Statiq.Core;
using Statiq.Web.Pipelines;
using System.Xml.Linq;

namespace Statiqdev
{
    public class ChildrenShortcode : SyncShortcode
    {
        public override ShortcodeResult Execute(KeyValuePair<string, string>[] args, string content, IDocument document, IExecutionContext context)
        {
            var ul = new XElement("ul", new XAttribute("class", "list-group"));

            foreach(var child in document.GetChildren().Where(x => !x.GetBool("Hidden", false)))
            {              
                var li = new XElement("li", new XAttribute("class", "list-group-item"));

                var link = new XElement("a", new XAttribute("href", child.GetLink()));
                link.Add(child.GetTitle());
                li.Add(link);

                var description = child.GetString("Description", null);
                if(description != null)
                {
                    li.Add(new XElement("br"));
                    li.Add(new XElement("i", description));
                }

                ul.Add(li);
            }

            return ul.ToString();
        }
    }
}