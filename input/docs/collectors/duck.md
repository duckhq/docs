Title: Duck
Order: 5
Description: This collector collect builds from another Duck server.
---

This collector collect builds from another Duck server.
You can either fetch all builds, or specify a specific view to
fetch builds from.

<img src="/assets/remote_duck.png" />

# Example

```json
{
    "$schema": "https://duckhq.org/schema.json",
    "collectors": [
        {
            "duck": {
                "id": "other_duck_server",
                "serverUrl": "https://example.com:15825"
            }
        }
    ]
}
```

# Required fields

<?# JsonSchema type=DuckConfiguration required=true /?>

# Optional fields

<?# JsonSchema type=DuckConfiguration required=false /?>