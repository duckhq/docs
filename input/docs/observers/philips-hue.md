Title: Philips Hue
Order: 0
---

This observer controls Philips Hue lights.

# Example

```json
{
    "$schema": "https://duckhq.org/schema.json",
    "observers": [
        {
            "hue": {
                "id": "office_build_lamp",
                "hubUrl": "http://192.168.1.99",
                "username": "THE-HUE-USERNAME",
                "lights": [ "1", "3" ]
            }
        }
    ]
}
```

# Required fields

<?# JsonSchema type=HueConfiguration required=true /?>

# Optional fields

<?# JsonSchema type=HueConfiguration required=false /?>