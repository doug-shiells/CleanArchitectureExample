Clean Architecture Example

This can act as a boilerplate for future projects
It has implemented clean architecture with .Net Core 2.2 and EFCore

Generic repositories and IQueryable<T> are automatically added to the DI Container for every entity in the DbContext
All command handlers are automatically wired into the DI container
A generic command invoker means you only need to inject the command invoker and create concrete classes for commands in your controllers
Static Functions are used for queries, this may need to evolve to implementations of a query interface for more complex queries that require dependencies

Given that DbContexts are scoped each webrequest this means we are able to do away with the large UnitOfWork class
This makes our dependencies more explicit in our constructor for our commands, e.g. It is obvious I am dependent on the StudentRepository not just the enitre database
I have kept a unit of work class, but this is only used to act as a transaction factory, as transactions are IDisposables its a bit nicer to write
using(var transaction = unitOfWork.BeginTransaction())
{
    ...
} 
than it is to inject a transaction and call dispose explicitly, which is also avalable to you in the project.