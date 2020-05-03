Title: Debugger
Order: 6
---

The Debugger collector collect builds from a
[Ducktor server](https://github.com/duckhq/ducktor).

# Example

```json
{
    "$schema": "https://duckhq.org/schema.json",
    "collectors": [
        {
            "debugger": {
                "id": "ducktor_collector",
                "serverUrl": "http://example.com:5000",
            }
        }
    ]
}
```

# Required fields

<?# JsonSchema type=DebuggerConfiguration required=true /?>

# Optional fields

<?# JsonSchema type=DebuggerConfiguration required=false /?>