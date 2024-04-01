# Clean Architecture WebApi
This is a .NET 8 web api template that is using Clean Architecture along with other design patterns. You are free to use the template for any projects you want. You are also allowed to contribute to the repository with anything that you might find that any web api should implement.

# Design Patterns
## Repository Pattern
The repository pattern is used between the Application and Persistence-layer. All the repository interfaces will be found in Application -> Interfaces -> Repositories. The repositories will then be found in Persistence -> Repositories.

## Mediator Pattern
Mediator Pattern is used to handle CQRS between the WebApi and the Application. It is the WolverineFX Nuget package that are used to implement the design pattern.

## Result Pattern
Instead of returning Exceptions everywhere an a state is not as intended, the result pattern has been implemented, to better document any errors that might arise. The documented errors can be found in Domain -> Errors. The Error object and Result object is found in Domain -> Abstractions.
