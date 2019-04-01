# Tusk.Domain Layer

This will contain all entities, enums, exceptions, types and logic specific to the domain. The Entity Framework related classes are abstract, and should be considered in the same light as .NET Core. For testing, use an InMemory provider such as InMemory or SqlLite.
or example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.