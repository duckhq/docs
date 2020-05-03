Title: Azure DevOps
Order: 1
---

The Azure DevOps collector collect builds from either 
[Azure DevOps](https://azure.microsoft.com/en-us/services/devops/) or a on-prem 
[Azure DevOps 2019 Server](https://azure.microsoft.com/en-us/services/devops/server/) instance.

# Example

Below is an example of a configuration for an on-prem *Azure DevOps 2019 server*.  
To connect to *Azure DevOps* instead, remove the `serverUrl` field.

```json
"azure": {
    "id": "azure_cake",
    "serverUrl": "https://example.com/",
    "organization": "cake-build",
    "project": "cake",
    "definitions": [ "5", "6", "7" ],
    "branches": [
        "refs/heads/main",
        "refs/heads/develop"
    ],
    "credentials": "anonymous"
}
```

# Required fields

<?# JsonSchema type=AzureDevOpsConfiguration required=true credentialsType=AzureDevOpsCredentials /?>

# Optional fields

<?# JsonSchema type=AzureDevOpsConfiguration required=false /?>

# Credentials

The credentials fields is where you tell Duck how you want to authenticate
against Azure DevOps. If your project is public, you can use anonymous access,
but be aware that this might be throttled at any point by Azure DevOps.

<a href="#credentials"></a>

#### Anonymous access:

```json
"credentials": "anonymous"
```

#### Personal Access Token:

```json
"credentials" {
    "pat": "MY-SUPER-SECRET-TOKEN"
}
```

<div class="alert alert-info" role="alert">
  <i class="fad fa-info-circle icon-web"></i> Sensitive information such as 
  personal access tokens, can be put in environment variables.
</div>