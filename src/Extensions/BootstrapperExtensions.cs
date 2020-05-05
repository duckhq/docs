using Statiq.App;
using Statiq.Common;
using System.Collections.Generic;
using System.Linq;

namespace Duck
{
    public static class BootstrapperExtensions
    {
        public static Bootstrapper ConfigureDuck(this Bootstrapper bootstrapper, string owner, string repo, string branch, string version)
        {
            if (bootstrapper != null)
            {
                bootstrapper.AddSetting(Constants.Duck.Owner, owner);
                bootstrapper.AddSetting(Constants.Duck.Repository, repo);
                bootstrapper.AddSetting(Constants.Duck.Branch, branch);
                bootstrapper.AddSetting(Constants.Duck.Version, version);
            }
            return bootstrapper;
        }

        public static Bootstrapper ConfigureSite(this Bootstrapper bootstrapper, string owner, string repo, string branch)
        {
            if (bootstrapper != null)
            {
                bootstrapper.AddSetting(Constants.Site.Owner, owner);
                bootstrapper.AddSetting(Constants.Site.Repository, repo);
                bootstrapper.AddSetting(Constants.Site.Branch, branch);
            }
            return bootstrapper;
        }

        public static Bootstrapper ConfigureDeployment(this Bootstrapper bootstrapper, string deployBranch)
        {
            if (bootstrapper != null)
            {
                bootstrapper.AddSetting(Constants.Deployment.TargetBranch, deployBranch);
            }
            return bootstrapper;
        }
    }
}
