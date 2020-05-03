Title: Slack
Order: 1
---

This observer sends notifications to [Slack](https://slack.com).

# Example

```json
{
    "$schema": "https://duckhq.org/schema.json",
    "observers": [
        {
            "slack": {
                "id": "slack_observer",
                "credentials": {
                    "webhook": {
                        "url": "https://hooks.slack.com/services/webhook"
                    }
                }
            }
        }
    ]
}
```

# Required fields

<?# JsonSchema type=SlackConfiguration required=true credentialsType=SlackCredentials /?>

# Optional fields

<?# JsonSchema type=SlackConfiguration required=false /?>

# Credentials

The credentials fields is where you tell Duck how you want to authenticate
with Slack.

#### Webhook:

```json
"credentials": {
    "webhook": {
        "url": "https://hooks.slack.com/services/webhook"
    }
}
```

<div class="alert alert-info" role="alert">
  <i class="fad fa-info-circle icon-web"></i> Sensitive information such as 
  personal access tokens, can be put in environment variables.
</div>