Title: GitHub Actions
Order: 2
Description: This collector collect builds from GitHub Actions
---

This collector collect builds from
[GitHub Actions](https://github.com/features/actions).

# Example

```json
{
    "$schema": "https://duckhq.org/schema.json",
    "collectors": [
        {
            "github": {
                "id": "github_pullrequests",
                "owner": "duckhq",
                "repository": "duck",
                "workflow": "pull_request.yml",
                "credentials": {
                    "basic": {
                        "username": "patriksvensson",
                        "password": "hunter1!"
                    }
                }
            }
        }
    ]
}
```

# Required fields

<?# JsonSchema type=GitHubConfiguration required=true credentialsType=AzureDevOpsCredentials /?>

# Optional fields

<?# JsonSchema type=GitHubConfiguration required=false /?>

# Credentials

The credentials fields is where you tell Duck how you want to authenticate
with GitHub.

#### Basic authentication:

```json
"credentials": {
    "basic": {
        "username": "patriksvensson",
        "password": "hunter1!"
    }
}
```

<div class="alert alert-info" role="alert">
  <i class="fad fa-info-circle icon-web"></i> Sensitive information such as 
  personal access tokens, can be put in environment variables.
</div>