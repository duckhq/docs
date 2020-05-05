using Statiq.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Duck
{
    public static class ExecutionStateExtensions
    {
        public static string GetSchemaUrl(this IExecutionState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            var owner = state.Settings.GetString(Constants.Duck.Owner);
            var repository = state.Settings.GetString(Constants.Duck.Repository);
            var branch = state.Settings.GetString(Constants.Duck.Branch);
            var version = Version.Parse(state.Settings.GetString(Constants.Duck.Version));

            return $"https://raw.githubusercontent.com/{owner}/{repository}/{branch}/schemas/v{version.ToString(2)}.json";
        }
    }
}
