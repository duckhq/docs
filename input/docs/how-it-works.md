Title: How it works
Order: 1
---

# Overview

The server part is responsible for collecting information from different `collectors` and forward interesting events to `observers`. The aggregated information is available for other services (such as the Vue frontend) via a HTTP API.

Observers can either be dependent on events from all collectors, or opt in to one or more collectors. This makes it easy to setup team specific build lights or Slack integration that's only dependent on specific collectors.

<img src="/assets/overview.svg" />