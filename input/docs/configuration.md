Title: Configuration
Order: 4
---

Duck is configured using a JSON configuration file normally called `config.json`
residing in the same directory that the Duck executable can be found in.

You can also tell Duck explicitly what configuration file to use, by providing the
`--config` option when starting Duck.

```shell
> ./duck --config ~/duck.json
```

# Example

In the example below we configure Duck to fetch new builds from TeamCity and
GitHub Actions every 30 seconds. We also define a view that can be toggled
in the UI and only will show builds from the `teamcity_internal` collector.

```json
{
    "$schema": "https://duckhq.org/schema.json",
    "title": "ACME Dashboard",
    "interval": 30,
    "views": [
        {
            "id": "office_tv",
            "name": "Office TV", 
            "collectors": [ 
                "teamcity_internal"
            ]
        }
    ],
    "collectors": [
        {
            "teamcity": {
                "id": "teamcity_internal",
                "serverUrl": "https://${TEAMCITY_HOST}:${TEAMCITY_PORT}/",
                "credentials": "guest",
                "builds": [
                    "My_Project_Definition",
                    "My_Other_Build_Definition"
                ]
            }
        },
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
    ],
    "observers": [
        {
            "hue": {
                "id": "hue_all_builds_dimmed",
                "hubUrl": "http://192.168.1.99",
                "username": "THE-HUE-USERNAME",
                "brightness": 50,
                "lights": [ "2", "3" ]
            }
        }
    ]
}
```

# Required fields

<?# JsonSchema type=Root required=true /?>

# Optional fields

<?# JsonSchema type=Root required=false /?>