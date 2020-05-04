Title: TeamCity
Order: 0
Description: This collector collect builds from TeamCity
---

The TeamCity collector collect builds from a [TeamCity build server](https://www.jetbrains.com/teamcity).  

# Example

```json
{
    "$schema": "https://duckhq.org/schema.json",
    "collectors": [
        {
            "teamcity": {
                "id": "teamcity_local",
                "serverUrl": "192.168.0.1:8111",
                "credentials": {
                    "basic": {
                        "username": "admin",
                        "password": "hunter1!"
                    }
                },
                "builds": [
                    "My_Build_Configation",
                    "My_Other_Build_Configation"
                ]
            }
        }
    ]
}
```

# Required fields

<?# JsonSchema type=TeamCityConfiguration required=true credentialsType=TeamCityCredentials /?>

# Optional fields

<?# JsonSchema type=TeamCityConfiguration required=false /?>

# Credentials

The credentials fields is where you tell Duck how you want to authenticate
with TeamCity.

#### Guest:

```json
"credentials": "guest"
```

#### Basic authentication:

```json
"credentials": {
    "basic": {
        "username": "admin",
        "password": "hunter1!"
    }
}
```

<div class="alert alert-info" role="alert">
  <i class="fad fa-info-circle icon-web"></i> Sensitive information such as 
  personal access tokens, can be put in environment variables.
</div>