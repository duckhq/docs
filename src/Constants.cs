namespace Duck
{
    public static class Constants
    {
        public const string NoContainer = nameof(NoContainer);
        public const string NoSidebar = nameof(NoSidebar);
        public const string Topic = nameof(Topic);
        public const string SchemaUri = nameof(SchemaUri);
        public const string EditLink = nameof(EditLink);
        public const string Description = nameof(Description);
        public const string Hidden = nameof(Hidden);

        public static class Deployment
        {
            public const string Owner = "DUCK_DEPLOYMENT_OWNER";
            public const string Repository = "DUCK_DEPLOYMENT_REPO";
            public const string GitHubToken = "GITHUB_TOKEN";
            public const string Branch = "DUCK_DEPLOYMENT_BRANCH";
        }

        public static class JsonSchema
        {
            public const string Root = nameof(Root);
            public const string Definitions = nameof(Definitions);
        }

        public static class Sections
        {
            public const string Splash = nameof(Splash);
            public const string Sidebar = nameof(Sidebar);
            public const string Subtitle = nameof(Subtitle);
        }
    }
}
