## What is Neo4jClient?
A .NET client for neo4j. Supports basic CRUD operations, Cypher and Gremlin queries via fluent interfaces, and some indexing operations.

## Why has this been forked?
This is a fork of the Readify [Neo4jClient](https://github.com/Readify/Neo4jClient) repository with BOLT support removed.

## Why has this been done?
Here at Barnardos we've started using [Neo4jMapper](https://github.com/barnardos-au/Neo4jMapper) in place of Neo4jClient, particularly for queries using the BOLT driver.

[Neo4j .NET Driver](https://github.com/neo4j/neo4j-dotnet-driver) is going through some API changes which is/has resulted in changes being made to Neo4jClient, in particular dropping support of synchronous methods. This will affect us as we have a lot of legacy code, most of which is not async.

By removing support for BOLT and unbundling the Neo4j .NET Driver we can support our existing code while moving forward with Neo4jMapper and any future changes to Neo4j .NET Driver APIs.

Grab the latest drop straight from the `Barnardos.Neo4jClient` package on [NuGet](https://www.nuget.org/packages/Barnardos.Neo4jClient/).

Read [Readify wiki doco](https://github.com/Readify/Neo4jClient/wiki).

## License Information

Licensed under MS-PL. See `LICENSE` in the root of this repository for full license text.
