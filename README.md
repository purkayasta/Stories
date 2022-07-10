# Dynamic Sharding

There are four common types of sharding strategies.

1. Horizontal or range based.
2. Vertical.
3. Key based (Algorithmic).
4. Directory based(Dynamic).

Directory based shard partitioning involves placing a lookup service in front of the sharded databases. The lookup service knows the current partitioning scheme and keeps a map of each entity and which database shard it is stored on. The lookup service is usually implemented as a webservice.

Interested ? 
Please visit https://pritom.hashnode.dev for more 🌮