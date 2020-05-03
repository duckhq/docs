Title: Octopus Deploy
Order: 3
---

The Octopus Deploy collector collect deployments from an [Octopus Deploy server](https://octopus.com).  

# Example

```json
{
    "$schema": "https://duckhq.org/schema.json",
    "collectors": [
        {
            "octopus": {
                "id": "octopus_server",
                "serverUrl": "https://example.com:9000",
                "credentials": {
                    "apiKey": "OCTOPUS-API-KEY"
                },
                "projects": [
                    {
                        "projectId": "Project-1",
                        "environments": [
                            "Environment-1",
                            "Environment-2"
                        ]
                    }
                ]
            }
        }
    ]
}
```

# Required fields

<?# JsonSchema type=OctopusDeployConfiguration required=true credentialsType=OctopusDeployCredentials /?>

# Optional fields

<?# JsonSchema type=OctopusDeployConfiguration required=false /?>

# Credentials

The credentials fields is where you tell Duck how you want to authenticate
with Octopus Deploy.

#### API Key:

```json
"credentials": {
    "apiKey": "OCTOPUS-API-KEY"
}
```

<div class="alert alert-info" role="alert">
  <i class="fad fa-info-circle icon-web"></i> Sensitive information such as 
  personal access tokens, can be put in environment variables.
</div>