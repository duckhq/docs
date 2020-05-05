using Statiq.Common;
using Statiq.Core;
using Statiq.Web.GitHub;

namespace Duck.Pipelines
{
    public class MirrorSchemaPipeline : Pipeline
    {
        public MirrorSchemaPipeline()
        {
            InputModules = new ModuleList
            {
                new ExecuteConfig(Config.FromContext(ctx => 
                {
                    return new ReadWeb(ctx.Settings.GetString(Constants.SchemaUri));
                }))
            };
            
            ProcessModules = new ModuleList
            {
                new SetDestination("schema.json")
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}
