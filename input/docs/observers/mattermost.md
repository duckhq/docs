Title: Mattermost
Order: 2
Description: This observer sends notifications to Mattermost
---

This observer sends notifications to [Mattermost](https://mattermost.com).

# Example

```json
{
    "$schema": "https://duckhq.org/schema.json",
    "observers": [
        {
            "mattermost": {
                "id": "mattermost",
                "channel": "build-status",
                "credentials": {
                    "webhook": {
                        "url": "https://mattermost.example.com"
                    }
                }
            }
        }
    ]
}
```

# Required fields

<?# JsonSchema type=MattermostConfiguration required=true credentialsType=MattermostCredentials /?>

# Optional fields

<?# JsonSchema type=MattermostConfiguration required=false /?>

# Credentials

The credentials fields is where you tell Duck how you want to authenticate
with Mattermost.

#### Webhook:

```json
"credentials": {
    "webhook": {
        "url": "https://example.com/mattermost"
    }
}
```

<div class="alert alert-info" role="alert">
  <i class="fad fa-info-circle icon-web"></i> Sensitive information such as 
  personal access tokens, can be put in environment variables.
</div>