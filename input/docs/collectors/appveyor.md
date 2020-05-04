Title: AppVeyor
Order: 4
Description: This collector collect builds from AppVeyor
---

This collector collect builds from [AppVeyor](https://www.appveyor.com/).  

# Example

```json
{
    "$schema": "https://duckhq.org/schema.json",
    "collectors": [
        {
            "appveyor": {
                "id": "appveyor",
                "credentials": {
                    "bearer": "SUPER-SECRET-TOKEN"
                },
                "account": "myaccount",
                "project": "myproject-slug"
            }
        }
    ]
}
```

# Required fields

<?# JsonSchema type=AppVeyorConfiguration required=true credentialsType=AppVeyorCredentials /?>

# Optional fields

<?# JsonSchema type=AppVeyorConfiguration required=false /?>

# Credentials

The credentials fields is where you tell Duck how you want to authenticate
with AppVeyor.

#### Bearer token:

```json
"credentials": {
    "bearer": "APPVEYOR-API-KEY"
}
```

<div class="alert alert-info" role="alert">
  <i class="fad fa-info-circle icon-web"></i> Sensitive information such as 
  personal access tokens, can be put in environment variables.
</div>