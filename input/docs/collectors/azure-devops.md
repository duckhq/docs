Title: Azure DevOps
Order: 1
---

The Azure DevOps collector collect builds from either Azure DevOps or a on-prem Azure DevOps 2019 Server instance.

# Configuration

```json
"azure":{
    "id":"azure_fedora",
    "enabled":true,
    "organization":"cake-build",
    "project":"cake",
    "definitions":[
        "6"
    ],
    "branches":[
        "refs/heads/main",
        "refs/heads/develop"
    ],
    "credentials":"anonymous"
}
```

## Required fields

<table class="table">
  <tr>
    <th>Field</th>
    <th>Type</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>id</td>
    <td>string</td>
    <td>A unique ID for the collector.</td>
  </tr>
  <tr>
    <td>organization</td>
    <td>string</td>
    <td>The organization to fetch builds from.</td>
  </tr>
  <tr>
    <td>project</td>
    <td>string</td>
    <td>The project within the organization to fetch builds from.</td>
  </tr>
  <tr>
    <td>definitions</td>
    <td>string[]</td>
    <td>The build definition to fetch builds for.</td>
  </tr>
  <tr>
    <td>credentials</td>
    <td>string</td>
    <td>The credentials to use.</td>
  </tr>
</table>

## Optional fields

<table class="table">
  <tr>
    <th>Field</th>
    <th>Type</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>enabled</td>
    <td>boolean</td>
    <td>Whether or not the collector is enabled.</td>
  </tr>
</table>

## Credentials

The credentials fields is where you tell Duck how you want to authenticate
against Azure DevOps. If your project is public, you can use anonymous access,
but be aware that this might be throtteled at any point by Azure DevOps.

### Anonymous access

```json
"credentials": "anonymous"
```

### Personal Access Token

```json
"credentials" {
    "pat": "MY-SUPER-SECRET-TOKEN"
}
```

<div class="alert alert-info" role="alert">
  <i class="fad fa-info-circle icon-web"></i> Sensitive information such as 
  personal access tokens, can be put in environment variables.
</div>