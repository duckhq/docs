using System.Collections.Generic;
using Statiq.Common;
using System.Linq;
using System;

namespace Duck.Shortcodes
{
    public class DownloadLinkShortcode : SyncShortcode
    {
        public override ShortcodeResult Execute(KeyValuePair<string, string>[] args, string content, IDocument document, IExecutionContext context)
        {
            var filename = args.FirstOrDefault(x => x.Key?.Equals("filename", StringComparison.OrdinalIgnoreCase) ?? false).Value;
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new InvalidOperationException("Filename is missing.");
            }

            return string.Format("https://github.com/duckhq/duck/releases/download/{0}/duck-{0}-{1}", 
                context.Settings.GetString(Constants.Duck.Version), filename);
        }
    }
}